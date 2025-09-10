using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public class SoftDeleteEmployeeHandler : IRequestHandler<SoftDeleteEmployeeRequest, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeRepository;

    public SoftDeleteEmployeeHandler(IEmployeeWriteRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public async Task<Result<string>> Handle(SoftDeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        await employeeRepository.SoftDeleteByRowIdAsync(request.RowId);
        return Result<string>.Success(null);
    }
}
