using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace ERP.Domain.ValueObjects;

public record PhoneNumber : StringValueObject
{
    private static readonly Regex _regex = new(@"^\d{11}$", RegexOptions.Compiled);

    public PhoneNumber(string value) : base(value, nameof(PhoneNumber))
    {
        if (!_regex.IsMatch(value))
            throw new InvalidPhoneNumberException("Phone number must be exactly 11 digits.");
    }

    public static implicit operator PhoneNumber(string value) => new PhoneNumber(value);
    public static implicit operator string(PhoneNumber value) => value.Value;
}
