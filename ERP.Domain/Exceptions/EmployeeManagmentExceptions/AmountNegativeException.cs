using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class AmountNegativeException : EmployeeManagmentException
{
    public AmountNegativeException() : base("unexpected amount")
    {
    }
}
