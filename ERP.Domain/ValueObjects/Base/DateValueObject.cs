namespace ERP.Domain.ValueObjects.Base;

public abstract record DateValueObject
{
    public DateTime Value { get; }

    protected DateValueObject(DateTime value, bool mustBePast, string fieldName)
    {
        if (mustBePast && value >= DateTime.UtcNow)
            throw new ArgumentException($"{fieldName} must be a date in the past.");

        Value = value;
    }

    public override string ToString() => Value.ToString("u");
}
