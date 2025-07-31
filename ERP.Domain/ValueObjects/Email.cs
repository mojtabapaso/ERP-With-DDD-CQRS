using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace ERP.Domain.ValueObjects;

public record Email : StringValueObject
{
    private static readonly Regex _regex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public Email(string value) : base(value, nameof(Email))
    {
        if (!_regex.IsMatch(value))
            throw new InvalidEmailException("Email format is invalid.");
    }

    public static implicit operator Email(string value) => new Email(value);
    public static implicit operator string(Email email) => email.Value;
}
