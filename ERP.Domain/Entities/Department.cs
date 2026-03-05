using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Department : BaseEntity
{
    // for EF 
    public Department() : base()
    {
    }
    private Department(string name, string description, ICollection<Employee> Employees)
    {
         
    }
    private string _name;
    private string _description;
    public NameValueObject Name =>_name;
    public DescriptionValueObject Description => _description;
    public ICollection<Employee> Employees { get; private set; } = new List<Employee>();

    //factory method 
    public static Department Create(string name, string description, ICollection<Employee> Employees)
    {
        return new Department(name, description, Employees);
    }

}
