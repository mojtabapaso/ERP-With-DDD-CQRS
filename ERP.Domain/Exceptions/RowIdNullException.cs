using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions;

internal class RowIdNullException : AuthenticationManagmentException
{
    public RowIdNullException() : base("Row Id can not null ")
    {
    }
}