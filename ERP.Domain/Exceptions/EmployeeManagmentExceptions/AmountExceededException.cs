using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class AmountExceededException : EmployeeManagmentException
{
    public AmountExceededException(int MaxAmount) : base($"Exceeded than {MaxAmount}")
    {
    }
}
