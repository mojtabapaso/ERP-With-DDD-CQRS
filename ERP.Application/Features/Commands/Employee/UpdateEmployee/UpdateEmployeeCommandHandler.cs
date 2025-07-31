using ERP.Domain.Entities;
using ERP.Domain.Factories.EmployeeManagment;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Abstraction.Commmand;
//using EmployeeEntity = ERP.Domain.Entities.Employee;
namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeWriteRepository employeeRepository;
    private readonly IEmployeeFactory employeeFactory;

    public UpdateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository, IEmployeeFactory employeeFactory)
    {
        this.employeeRepository = employeeRepository;
        this.employeeFactory = employeeFactory;
    }

    public async Task ExecuteAsync(UpdateEmployeeCommand command)
    {
        var employeeExist = await employeeRepository.ExistByIdAsync(command.id);
        if (!employeeExist)
            throw new EmployeeNotFoundException();
        var employeeFac = employeeFactory.Create( command.firstName, command.lastName, command.nationalCode, command.birthDateUtc, command.employeePosition, command.companyId, command.company);
        await employeeRepository.UpdateAsync(employeeFac);

    }
}
