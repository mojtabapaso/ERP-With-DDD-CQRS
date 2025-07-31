namespace ERP.Shared.Abstraction.Exceptions;

public abstract class EmployeeManagmentException : Exception
{
    protected EmployeeManagmentException(string message) : base(message)
    {

    }
}

