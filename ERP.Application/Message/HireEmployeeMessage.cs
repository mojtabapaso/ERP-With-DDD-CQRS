namespace ERP.Application.Message;

public sealed record HireEmployeeMessage
{
    public int? EmployeeId { get; init; }
}

