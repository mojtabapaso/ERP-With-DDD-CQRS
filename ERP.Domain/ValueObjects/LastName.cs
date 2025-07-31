using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record LastName : StringValueObject
{
    public LastName(string value) : base(value, nameof(LastName)) { }

    public static implicit operator LastName(string value) => new LastName(value);
    public static implicit operator string(LastName value) => value.Value;
}
