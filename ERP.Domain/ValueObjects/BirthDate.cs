using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.ValueObjects;

public record BirthDate
{
    public DateTime Value { get; }
    public BirthDate(DateTime value)
    {
        if (value > DateTime.UtcNow)
        {
            throw new InvalidBirthDateException();
        }
        Value = value;
    }
    public static implicit operator BirthDate(DateTime dateTime) => new BirthDate(dateTime);
    public static implicit operator DateTime(BirthDate birthDate) => birthDate.Value;
}