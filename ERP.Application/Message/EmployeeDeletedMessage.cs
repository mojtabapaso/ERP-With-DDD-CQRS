namespace ERP.Application.Message;

public record EmployeeDeletedMessage : BaseMessage
{
    public Guid EmployeeRowId { get; init; }
    public int EmployeeId { get; init; }

    public bool IsDeleted { get; init; }
}