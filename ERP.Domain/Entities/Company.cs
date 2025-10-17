using ERP.Domain.Common;
using ERP.Domain.ValueObjects;
using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.Entities;

public class Company : BaseEntity
{


    private Name _name;
    private TaxCode _taxCode;
    private PhoneNumber _phoneNumber;
    private Address _address;
    private ICollection<Employee> _employees = new List<Employee>();
    public Company() : base()
    {

    }
    ////==
    public Name Name => _name;
    public TaxCode TaxCode => _taxCode;
    public PhoneNumber PhoneNumber => _phoneNumber;
    public Address Address => _address;
    public ICollection<Employee> Employees => _employees;
}   