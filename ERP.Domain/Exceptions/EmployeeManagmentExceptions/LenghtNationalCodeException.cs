using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class LenghtNationalCodeException : EmployeeManagmentException
{
    public LenghtNationalCodeException() : base("Last name Can not be null")
    {
    }
}
