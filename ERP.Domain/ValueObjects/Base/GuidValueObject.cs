namespace ERP.Domain.ValueObjects.Base;

public abstract record GuidValueObject
{
    public Guid Value { get; }

    protected GuidValueObject(Guid value, string fieldName)
    {
        if (value == Guid.Empty)
            throw new ArgumentException($"{fieldName} can't be empty GUID.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
