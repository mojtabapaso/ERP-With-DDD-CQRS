using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.ValueObjects;

public record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new InvalidMoneyValueException("Money amount cannot be negative.");

        Value = value;
    }

    public static implicit operator Money(decimal value) => new Money(value);
    public static implicit operator decimal(Money money) => money.Value;
}
