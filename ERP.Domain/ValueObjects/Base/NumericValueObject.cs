namespace ERP.Domain.ValueObjects.Base;
public abstract record NumericValueObject<T> where T : struct, IComparable<T>
{
    public T Value { get; }

    protected NumericValueObject(T value, T minValue, string fieldName)
    {
        if (value.CompareTo(minValue) < 0)
            throw new ArgumentOutOfRangeException($"{fieldName} must be >= {minValue}");

        Value = value;
    }

    public override string ToString() => Value.ToString()!;
}
