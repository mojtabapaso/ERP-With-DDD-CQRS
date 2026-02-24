using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace ERP.Domain.ValueObjects;

public record PhoneNumberValueObject : StringValueObject
{
    private static readonly Regex _regex = new(@"^\d{11}$", RegexOptions.Compiled);

    public PhoneNumberValueObject(string value) : base(value, nameof(PhoneNumberValueObject))
    {
        if (!_regex.IsMatch(value))
            throw new InvalidPhoneNumberException("Phone number must be exactly 11 digits.");
    }

    public static implicit operator PhoneNumberValueObject(string value) => new PhoneNumberValueObject(value);
    public static implicit operator string(PhoneNumberValueObject value) => value.Value;
}
