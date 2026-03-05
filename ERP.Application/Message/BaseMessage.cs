namespace ERP.Application.Message;

public abstract record BaseMessage
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}

