using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer() :base()
    {
    }
    // ───── Backing Fields ─────
    private FullNameValueObject _fullName;
    private PhoneNumberValueObject _phoneNumber;
    private EmailValueObject _email;
    private AddressValueObject _address;
    // ───── Public Read-Only Properties ─────
    public FullNameValueObject FullName =>_fullName;
    public EmailValueObject Email => _email;
    public PhoneNumberValueObject PhoneNumber =>_phoneNumber;
    public AddressValueObject Address =>_address;

}
