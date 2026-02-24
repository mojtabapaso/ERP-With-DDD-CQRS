using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record TaxCodeValueObject : StringValueObject
{
    public TaxCodeValueObject(string value) : base(value, nameof(TaxCodeValueObject)) { }
    public static implicit operator TaxCodeValueObject(string value) => new TaxCodeValueObject(value);
    public static implicit operator string(TaxCodeValueObject value) => value.Value;
}

