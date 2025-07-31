using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record FirstName : StringValueObject
{
    public FirstName(string value):base(value, nameof(FirstName)) { }
    public static implicit operator FirstName(string value) => new FirstName(value);
    public static implicit operator string(FirstName value) => value.Value;
}


public record Name : StringValueObject
{
    public Name(string value) : base(value, nameof(Name)) { }
    public static implicit operator Name(string value) => new Name(value);
    public static implicit operator string(Name value) => value.Value;
}

public record TaxCode : StringValueObject
{
    public TaxCode(string value) : base(value, nameof(TaxCode)) { }
    public static implicit operator TaxCode(string value) => new TaxCode(value);
    public static implicit operator string(TaxCode value) => value.Value;
}

public record Address : StringValueObject
{
    public Address(string value) : base(value, nameof(Address)) { }
    public static implicit operator Address(string value) => new Address(value);
    public static implicit operator string(Address value) => value.Value;
}

