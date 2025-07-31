using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Department : BaseEntity
{
    public Department() : base(default!)
    {
    }

    public string Name { get; set; } = default!;
    public string Description { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
