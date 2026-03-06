using ERP.Domain.Events.EmployeeManagment;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MassTransit;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.HireEmployee;

public class HireEmployeeCommandHandler : IRequestHandler<HireEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly IPublishEndpoint publishEndpoint;

    public HireEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository, IPublishEndpoint publishEndpoint)
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

        //:TODO use mapper hear 
        var newEmployee = Domain.Entities.Employee.Hire(request.HireEmpoyeeDto.FirstName, request.HireEmpoyeeDto.LastName,
            request.HireEmpoyeeDto.NationalCode, request.HireEmpoyeeDto.BirthDate,
            request.HireEmpoyeeDto.EmployeePosition, request.HireEmpoyeeDto.CompanyId,
            request.HireEmpoyeeDto.DegreeLevel, request.HireEmpoyeeDto.Salary);
        await employeeWriteRepository.CreateAsync(newEmployee);

        foreach (EmployeeHiredEvent item in newEmployee.DomainEvents)
        {
            await publishEndpoint.Publish(item, cancellationToken);
        }
        newEmployee.ClearDomainEvents();
        return Result<string>.Success("ok");
    }
}