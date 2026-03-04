using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Department : BaseEntity
{
    public Department() : base(default!)
    {
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; }
    public ICollection<Employee> Employees { get; private set; } = new List<Employee>();
}
