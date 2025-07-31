using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Shared.Abstraction.Quaries;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Queries.Employee.GetEmployeeByRowId;
 public sealed record GetEmployeeByRowIdQuery(Guid RowId) : IRequest<Result<EmployeeDto>>;

