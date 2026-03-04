using ERP.Application.Message;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MassTransit;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.HireEmployee;

public class HireEmployeeCommandHandler : IRequestHandler<HireEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly IPublishEndpoint publishEndpoint;

    public HireEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository, IPublishEndpoint publishEndpoint )
    {
        this.employeeWriteRepository = employeeWriteRepository;
        this.publishEndpoint = publishEndpoint;
    }
    public async Task<Result<string>> Handle(HireEmployeeRequest request, CancellationToken cancellationToken)
    {
        HireEmployeeValidator validator = new HireEmployeeValidator();
        var isValid = await validator.ValidateAsync(request.HireEmpoyeeDto);
        if (!isValid.IsValid)
        {
            return Result<string>.Error(isValid.Errors.Select(x => x.ErrorMessage).ToList());
        }
        var employee = new ERP.Domain.Entities.Employee();
        //:TODO use mapper hear 
        var newEmployee = employee.Create(request.HireEmpoyeeDto.FirstName, request.HireEmpoyeeDto.LastName, request.HireEmpoyeeDto.NationalCode, request.HireEmpoyeeDto.BirthDate, request.HireEmpoyeeDto.EmployeePosition, request.HireEmpoyeeDto.CompanyId, request.HireEmpoyeeDto.DegreeLevel);
        await employeeWriteRepository.CreateAsync(newEmployee);

        await publishEndpoint.Publish(new HireEmployeeMessage
        {
            EmployeeRowId = newEmployee.RowId,
            EmployeeId = newEmployee.Id,
            FirstName = newEmployee.FirstName.Value,
            LastName = newEmployee.LastName.Value,
            NationalCode = newEmployee.NationalCode.Value,
            BirthDateUtc = newEmployee.BirthDateUtc.Value,
            EmployeePosition = (int)newEmployee.EmployeePosition,
           // CompanyId = companyRowId,
            DegreeLevel = (int)newEmployee.DegreeLevel
        }, cancellationToken);

        return Result<string>.Success("ok");

    }
}