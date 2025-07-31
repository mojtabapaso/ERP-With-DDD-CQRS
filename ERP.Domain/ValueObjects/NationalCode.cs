using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace ERP.Domain.ValueObjects;

public record NationalCode : StringValueObject
{
    public NationalCode(string value) : base(value, nameof(NationalCode))
    {
        if (value.Length != 10)
            throw new InvalidNationalCodeException("National code must be exactly 10 digits.");

        if (!Regex.IsMatch(value, @"^\d{10}$"))
            throw new InvalidNationalCodeException("National code must contain only numeric digits.");

        var check = Convert.ToInt32(value[9].ToString());
        var sum = Enumerable.Range(0, 9)
            .Select(i => Convert.ToInt32(value[i].ToString()) * (10 - i))
            .Sum() % 11;

        var isValid = sum < 2 ? check == sum : (11 - sum) == check;

        if (!isValid)
            throw new InvalidNationalCodeException("Invalid national code format.");
    }

    public static implicit operator NationalCode(string value) => new NationalCode(value);
    public static implicit operator string(NationalCode value) => value.Value;
}
