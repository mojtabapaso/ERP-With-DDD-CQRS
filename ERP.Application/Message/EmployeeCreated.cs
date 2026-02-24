namespace ERP.Application.Message;

public record EmployeeCreated
{
    public Guid EventId { get; init; } = Guid.NewGuid();   
    public DateTime Timestamp { get; init; } = DateTime.UtcNow; 
    public Guid EmployeeRowId { get; init; }
    public int? EmployeeId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public DateTime BirthDateUtc { get; init; }
    public int EmployeePosition { get; init; }
    public Guid CompanyId { get; init; }
    public int DegreeLevel { get; init; }
}

public record EmployeeUpdated
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public Guid EmployeeRowId { get; init; }
    public int EmployeeId { get; init; }

    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public DateTime BirthDateUtc { get; init; }
    public int EmployeePosition { get; init; }
    public Guid CompanyId { get; init; }
    public int? DegreeLevel { get; init; }
}

public record EmployeeDeleted
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public Guid EmployeeRowId { get; init; }
    public int EmployeeId { get; init; }

    public bool IsDeleted { get; init; }
}