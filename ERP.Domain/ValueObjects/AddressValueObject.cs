using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record AddressValueObject : StringValueObject
{
    public AddressValueObject(string value) : base(value, nameof(AddressValueObject)) { }
    public static implicit operator AddressValueObject(string value) => new AddressValueObject(value);
    public static implicit operator string(AddressValueObject value) => value.Value;
}

