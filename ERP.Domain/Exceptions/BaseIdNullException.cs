using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions;

internal class BaseIdNullException : AuthenticationManagmentException
{
    public BaseIdNullException() : base("Id can not null ")
    {
    }
}
