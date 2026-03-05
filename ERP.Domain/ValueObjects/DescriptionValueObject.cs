using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record DescriptionValueObject : StringValueObject
{
    public DescriptionValueObject(string value) : base(value, nameof(DescriptionValueObject)) { }
    public static implicit operator DescriptionValueObject(string value) => new DescriptionValueObject(value);
    public static implicit operator string(DescriptionValueObject value) => value.Value;
}