using ERP.Domain.ValueObjects;
using ERP.Shared.Common.ResultPattern;
using MediatR;
namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public class SoftDeleteEmployeeRequest : IRequest<Result<string>>
{
    public RowId RowId { get; set; }

}