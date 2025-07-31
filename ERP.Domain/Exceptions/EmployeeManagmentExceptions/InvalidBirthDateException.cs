using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class InvalidBirthDateException : EmployeeManagmentException
{
    public InvalidBirthDateException() : base("Birth date is invalid")
    {
    }
}
