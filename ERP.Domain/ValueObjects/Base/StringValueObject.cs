namespace ERP.Domain.ValueObjects.Base;

public abstract record StringValueObject
{
    public string Value { get; }

    protected StringValueObject(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException($"The {fieldName} can't be null or empty");

        Value = value;
    }

    public override string ToString() => Value;
}
