using ERP.Domain.Enums;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.DTOs.EmployeeDTOs;

public sealed record TransferToCompanyDto :  IRequest<Result<string>>
{
    public Guid EmployeeId { get; init; }
    public int NewCompanyId { get; init; }
    public EmployeePosition EmployeePosition { get; init; }

}