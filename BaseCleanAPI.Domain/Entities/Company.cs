using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = default!;
    public string TaxCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}