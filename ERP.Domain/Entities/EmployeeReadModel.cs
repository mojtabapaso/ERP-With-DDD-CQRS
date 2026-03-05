namespace ERP.Domain.Entities;

public class EmployeeReadModel
{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NationalCode { get; set; } = string.Empty;
    public DateTime BirthDateUtc { get; set; }
    public string EmployeePosition { get; set; } = string.Empty;
    public string DegreeLevel { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
}