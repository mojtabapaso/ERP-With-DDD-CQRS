using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public async Task<Result<string>> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateEmpoyeeDto;
        var employee = await employeeRepository.GetByRowIdAsync(dto.RowId);
        if (employee == null)
            throw new EmployeeNotFoundException();

        employee.Update(
                dto.FirstName,
                dto.LastName,
                dto.NationalCode,
                dto.BirthDate,
                dto.EmployeePosition,
                dto.CompanyId,
                dto.DegreeLevel
            );

        // 3. Save updated entity
        await employeeRepository.UpdateAsync(employee);

        return Result<string>.Success("ok");

    }
}
