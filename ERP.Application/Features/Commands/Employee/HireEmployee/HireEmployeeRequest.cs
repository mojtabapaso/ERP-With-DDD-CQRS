using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.HireEmployee;

public class HireEmployeeRequest : IRequest<Result<string>>
{
    public HireEmployeeDto HireEmpoyeeDto { get; set; }
}
