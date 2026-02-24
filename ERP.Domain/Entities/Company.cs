using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;


public class EmployeeHiredEvent
{
    public int Id;
    public int EmployeeId;
    public EmployeeHiredEvent(int Id, int EmployeeId)
    {
        this.Id = Id;
        this.EmployeeId = EmployeeId;

    }
}


public class Company : BaseEntity
{
    public Company() : base()  {  }
    public NameValueObject Name { get; private  set; }
    public TaxCodeValueObject TaxCode { get; private set; }
    public PhoneNumberValueObject PhoneNumber { get; private set; }
    public AddressValueObject Address { get; private set; }
    public ICollection<Employee> Employees { get; private set; } = new List<Employee>();
    //public void HireEmployee(Employee employee)
    //{
    //    if (_employees.Any(e => e.NationalCode == employee.NationalCode))
    //        throw new DomainException("Employee with same national code already exists");

    //    _employees.Add(employee);
    //    RaiseEventEvent(new EmployeeHiredEvent(Id.Value, employee.Id.Value));
    //    IncrementedVersion();
    //}

    //public void FireEmployee(Guid employeeId, string reason)
    //{
    //    var employee = _employees.FirstOrDefault(e => e.RowId.Value == employeeId);
    //    if (employee == null)
    //        throw new DomainException("Employee not found");

    //    employee.Fire(reason);
    //    RaiseEventEvent(new EmployeeFiredEvent(Id, employee.Id, reason));
    //    IncrementedVersion();
    //}

}