using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Employees.Commands.CreateEmployee;
using ERP.Domain.Factories.EmployeeManagment;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.CreateEmployee;

//public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
//{
//    private readonly IEmployeeRepository employeeRepository;
//    private readonly IEmployeeFactory employeeFactory;
//    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
//    {
//        this.employeeRepository = employeeRepository;
//        this.employeeFactory = employeeFactory;
//    }
//    public async Task ExecuteAsync(CreateEmployeeCommand command)
//    {
//        var employee = employeeFactory.Create(command.id, command.rowId, false, DateTime.Now,null, command.firstName, command.lastName, command.nationalCode, command.birthDateUtc, command.employeePosition, command.companyId, command.company);
//        await employeeRepository.CreateAsync(employee);
//    }
//}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
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
        var employee = new EmployeeFactory();
        //:TODO use mapper hear 
        var newEmployee = employee.Create(request.CreateEmployeeDto.FirstName, request.CreateEmployeeDto.LastName, request.CreateEmployeeDto.NationalCode, request.CreateEmployeeDto.BirthDate, request.CreateEmployeeDto.EmployeePosition, request.CreateEmployeeDto.CompanyId, request.CreateEmployeeDto.DegreeLevel);
        await employeeRepository.CreateAsync(newEmployee);
        return Result<string>.Success("Create OK");
    }
}

