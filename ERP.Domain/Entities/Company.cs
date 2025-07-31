using ERP.Domain.Common;
using ERP.Domain.ValueObjects;
using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.Entities;

public class Company : BaseEntity
{
    public Company() : base()
    {

    }

    private Name _name;
    private TaxCode _taxCode;
    private PhoneNumber _phoneNumber;
    private Address _address;
    private ICollection<Employee> _employees = new List<Employee>();
}   