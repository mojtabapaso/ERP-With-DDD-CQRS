using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer() 
    {
    }

    public FullNameValueObject FullName { get; private set; }
    public PhoneNumberValueObject PhoneNumber { get; private set; }
    public EmailValueObject Email { get; private set; }
    public AddressValueObject Address { get; private set; }

}
