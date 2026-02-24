using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record FullNameValueObject : StringValueObject
{
    public FullNameValueObject(string value) : base(value, nameof(FirstName)) { }
    public static implicit operator FullNameValueObject(string value) => new FullNameValueObject(value);
    public static implicit operator string(FullNameValueObject value) => value.Value;
}