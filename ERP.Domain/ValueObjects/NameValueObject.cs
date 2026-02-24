using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record NameValueObject : StringValueObject
{
    public NameValueObject(string value) : base(value, nameof(NameValueObject)) { }
    public static implicit operator NameValueObject(string value) => new NameValueObject(value);
    public static implicit operator string(NameValueObject value) => value.Value;
}
