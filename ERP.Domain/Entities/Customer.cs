using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer() 
    {
    }

    public FullNameValueObject FullName { get; set; }
    public PhoneNumberValueObject PhoneNumber { get; set; }
    public EmailValueObject Email { get; set; }
    public AddressValueObject Address { get; set; }
}
