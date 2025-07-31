using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.ValueObjects;

public sealed record Amount
{
    public int Value { get; }

    public Amount(int value)
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
    public static implicit operator Amount(int value) => new Amount(value);
    public static implicit operator int(Amount amount) => amount.Value;

    // عملگرهای ریاضی امن
    public static Amount operator +(Amount a1, Amount a2)
        => new Amount(a1.Value + a2.Value);

    public static Amount operator -(Amount a1, Amount a2)
    {
        if (a1.Value < a2.Value)
            throw new InvalidOperationException("مقدار منفی مجاز نیست");
        return new Amount(a1.Value - a2.Value);
    }

    public static Amount operator *(Amount a, int multiplier)
        => new Amount(a.Value * multiplier);

    public static Amount operator /(Amount a, int divisor)
    {
        if (divisor <= 0)
            throw new DivideByZeroException();
        return new Amount(a.Value / divisor);
    }

    // مقایسه‌ها
    public bool IsGreaterThan(Amount other) => Value > other.Value;
    public bool IsLessThan(Amount other) => Value < other.Value;
    public bool IsZero() => Value == 0;
    public bool IsPositive() => Value > 0;

    // برای اعتبارسنجی‌های خاص‌تر
    public static bool TryCreate(int value, out Amount? amount)
    {
        if (value >= 0 && value <= MaxAmount)
        {
            amount = new Amount(value);
            return true;
        }

        amount = null;
        return false;
    }

    // برای نمایش
    public override string ToString() => $"{Value:N0} تومان";
}
