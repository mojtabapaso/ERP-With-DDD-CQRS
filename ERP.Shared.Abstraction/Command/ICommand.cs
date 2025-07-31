namespace ERP.Shared.Abstraction.Commmand;

public interface ICommand
{
}
// use for audit
/*
 public interface ICommand
{
    Guid CommandId { get; } // برای idempotency و tracing
    string? PerformedByUserId { get; }
    string? CorrelationId { get; }
    DateTime RequestedAt { get; }
}

 
 */
