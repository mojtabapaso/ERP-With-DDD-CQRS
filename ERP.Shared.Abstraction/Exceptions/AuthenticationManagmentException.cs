namespace ERP.Shared.Abstraction.Exceptions;

public abstract class AuthenticationManagmentException : Exception
{
    protected AuthenticationManagmentException(string message) : base(message)
    {

    }
}