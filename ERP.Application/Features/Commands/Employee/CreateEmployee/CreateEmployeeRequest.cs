using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Shared.Common.ResultPattern;
using MediatR;
namespace ERP.Application.Features.Commands.Employee.CreateEmployee;

public class CreateEmployeeRequest : IRequest<Result<string>>
{
    public CreateEmployeeDto CreateEmployeeDto { get; set; }
}