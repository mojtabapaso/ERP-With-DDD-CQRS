using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace ERP.Domain.ValueObjects;

public record EmailValueObject : StringValueObject
{
    private static readonly Regex _regex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public EmailValueObject(string value) : base(value, nameof(EmailValueObject))
    {
        if (!_regex.IsMatch(value))
            throw new InvalidEmailException("Email format is invalid.");
    }

    public static implicit operator EmailValueObject(string value) => new EmailValueObject(value);
    public static implicit operator string(EmailValueObject email) => email.Value;
}
