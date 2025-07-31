namespace ERP.Domain.ValueObjects.Base;

public abstract record EnumValueObject<TEnum> where TEnum : struct, Enum
{
    public TEnum Value { get; }

    protected EnumValueObject(TEnum value, string fieldName)
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
            throw new ArgumentException($"{fieldName} has invalid enum value.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
