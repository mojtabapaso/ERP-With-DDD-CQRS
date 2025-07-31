using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class InvalidFirstNameException : EmployeeManagmentException
{
    public InvalidFirstNameException() : base("Last name Can not be null")
    {
    }
}
