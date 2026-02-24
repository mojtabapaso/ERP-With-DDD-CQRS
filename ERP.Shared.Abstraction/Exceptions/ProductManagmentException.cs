namespace ERP.Shared.Abstraction.Exceptions;

public abstract class ProductManagmentException : Exception
{
    protected ProductManagmentException(string message) : base(message)
    {

    }
}