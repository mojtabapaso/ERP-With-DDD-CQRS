using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Employees.Commands.CreateEmployee;
using ERP.Shared.Common.ResultPattern;
using MassTransit.Transports;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.HireEmployee;

public class HireEmployeeRequest : IRequest<Result<string>>
{
    public HireEmployeeDto HireEmpoyeeDto { get; set; }
}
