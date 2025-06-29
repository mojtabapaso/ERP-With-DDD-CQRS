using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalCode { get; set; }
    public DateTime BirthDate { get; set; }
    public string Position { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;
}
