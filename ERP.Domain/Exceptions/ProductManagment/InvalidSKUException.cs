using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.ProductManagment;

internal class InvalidSKUException : ProductManagmentException
{
    public InvalidSKUException(string message) : base(message)
    {
    }
}
