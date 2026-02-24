using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record Address : StringValueObject
{
    public Address(string value) : base(value, nameof(Address)) { }
    public static implicit operator Address(string value) => new Address(value);
    public static implicit operator string(Address value) => value.Value;
}

