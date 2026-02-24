using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.ValueObjects;

public record MoneyValueObject
{
    public decimal Value { get; }

    public MoneyValueObject(decimal value)
    {
        if (value < 0)
            throw new InvalidMoneyValueException("Money amount cannot be negative.");

        Value = value;
    }

    public static implicit operator MoneyValueObject(decimal value) => new MoneyValueObject(value);
    public static implicit operator decimal(MoneyValueObject money) => money.Value;
}
