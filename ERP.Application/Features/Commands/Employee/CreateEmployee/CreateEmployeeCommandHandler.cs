using ERP.Application.Features.Employees.Commands.CreateEmployee;
using ERP.Application.Message;
using ERP.Domain.Repository;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MassTransit;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.CreateEmployee;



public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeRepository;
    private readonly ICompanyWriteRepository companyRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IOutboxEventDispatcher outboxEventDispatcher;

    public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository, ICompanyWriteRepository companyRepository, IPublishEndpoint publishEndpoint, IOutboxEventDispatcher outboxEventDispatcher)
    {
        this.employeeRepository = employeeRepository;
        this.companyRepository = companyRepository;
        _publishEndpoint = publishEndpoint;
        this.outboxEventDispatcher = outboxEventDispatcher;
    }

    public async Task<Result<string>> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        CreateEmployeeValidator validator = new CreateEmployeeValidator();
        var isValid = await validator.ValidateAsync(request.CreateEmployeeDto);
        if (!isValid.IsValid)
        {
            return Result<string>.Error(isValid.Errors.Select(x => x.ErrorMessage).ToList());
        }
        //TODO CancellationToken what it is ???
        var employee = new ERP.Domain.Entities.Employee();
        //:TODO use mapper hear 
        var newEmployee = employee.Create(request.CreateEmployeeDto.FirstName, request.CreateEmployeeDto.LastName, request.CreateEmployeeDto.NationalCode, request.CreateEmployeeDto.BirthDate, request.CreateEmployeeDto.EmployeePosition, request.CreateEmployeeDto.CompanyId, request.CreateEmployeeDto.DegreeLevel);
        await employeeRepository.CreateAsync(newEmployee);

        var companyRowId = await companyRepository.GetRowIdByIdAsync(newEmployee.CompanyId);

        // send  message in mass transit into rabbitmq
        await _publishEndpoint.Publish(new EmployeeCreated
        {
            EmployeeRowId = newEmployee.RowId,
            EmployeeId = newEmployee.Id,
            FirstName = newEmployee.FirstName.Value,
            LastName = newEmployee.LastName.Value,
            NationalCode = newEmployee.NationalCode.Value,
            BirthDateUtc = newEmployee.BirthDateUtc.Value,
            EmployeePosition = (int)newEmployee.EmployeePosition,
            CompanyId = companyRowId,
            DegreeLevel = (int)newEmployee.DegreeLevel
        }, cancellationToken);
        return Result<string>.Success("Create OK");
    }
}

