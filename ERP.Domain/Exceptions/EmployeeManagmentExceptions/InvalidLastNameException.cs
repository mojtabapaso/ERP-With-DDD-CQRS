using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class InvalidLastNameException : EmployeeManagmentException
{
    public InvalidLastNameException() : base("Last name Can not be null")
    {
    }
}
