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


    private NameValueObject _name;
    private TaxCodeValueObject _taxCode;
    private PhoneNumber _phoneNumber;
    private Address _address;
    private ICollection<Employee> _employees = new List<Employee>();
    public Company() : base()
    {

    }
    ////==
    public NameValueObject Name => _name;
    public TaxCodeValueObject TaxCode => _taxCode;
    public PhoneNumber PhoneNumber => _phoneNumber;
    public Address Address => _address;
    public ICollection<Employee> Employees => _employees;

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