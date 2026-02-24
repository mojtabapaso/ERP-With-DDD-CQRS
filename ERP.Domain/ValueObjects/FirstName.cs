using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record FirstName : StringValueObject
{
    public FirstName(string value):base(value, nameof(FirstName)) { }
    public static implicit operator FirstName(string value) => new FirstName(value);
    public static implicit operator string(FirstName value) => value.Value;
}