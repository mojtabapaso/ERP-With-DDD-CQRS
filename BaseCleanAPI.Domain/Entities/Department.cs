using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
