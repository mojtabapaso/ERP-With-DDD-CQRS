using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Shared.Common.ResultPattern;
using MediatR;
namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeRequest : IRequest<Result<string>>
{
    public UpdateEmpoyeeDto UpdateEmpoyeeDto { get; set; }
}