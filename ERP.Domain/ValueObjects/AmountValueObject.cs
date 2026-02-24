using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.ValueObjects;

public sealed record AmountValueObject
{
    public int Value { get; }

    public AmountValueObject(int value)
    {
        if (value < 0)
            throw new AmountNegativeException();

        if (value > MaxAmount)
            throw new AmountExceededException(MaxAmount);

        Value = value;
    }

    // حداکثر مقدار مجاز (مثلاً در سیاست مالی شرکت)
    public const int MaxAmount = 1_000_000_000; // 1 میلیارد

    // عملگرهای ضمنی برای راحتی استفاده
    public static implicit operator AmountValueObject(int value) => new AmountValueObject(value);
    public static implicit operator int(AmountValueObject amount) => amount.Value;

    // عملگرهای ریاضی امن
    public static AmountValueObject operator +(AmountValueObject a1, AmountValueObject a2)
        => new AmountValueObject(a1.Value + a2.Value);

    public static AmountValueObject operator -(AmountValueObject a1, AmountValueObject a2)
    {
        if (a1.Value < a2.Value)
            throw new InvalidOperationException("مقدار منفی مجاز نیست");
        return new AmountValueObject(a1.Value - a2.Value);
    }

    public static AmountValueObject operator *(AmountValueObject a, int multiplier)
        => new AmountValueObject(a.Value * multiplier);

    public static AmountValueObject operator /(AmountValueObject a, int divisor)
    {
        if (divisor <= 0)
            throw new DivideByZeroException();
        return new AmountValueObject(a.Value / divisor);
    }

    // مقایسه‌ها
    public bool IsGreaterThan(AmountValueObject other) => Value > other.Value;
    public bool IsLessThan(AmountValueObject other) => Value < other.Value;
    public bool IsZero() => Value == 0;
    public bool IsPositive() => Value > 0;

    // برای اعتبارسنجی‌های خاص‌تر
    public static bool TryCreate(int value, out AmountValueObject? amount)
    {
        if (value >= 0 && value <= MaxAmount)
        {
            amount = new AmountValueObject(value);
            return true;
        }

        amount = null;
        return false;
    }

    // برای نمایش
    public override string ToString() => $"{Value:N0} تومان";
}
