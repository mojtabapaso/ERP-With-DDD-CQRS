using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class InvalidLastNameException : EmployeeManagmentException
{
    public InvalidLastNameException() : base("Last name Can not be null")
    {
    }
}
internal class EmployeeNotActiveException : EmployeeManagmentException
{
    public EmployeeNotActiveException(string text) : base(text)
    {
    }
}


internal class LeaveRequestNotFoundException : EmployeeManagmentException
{
    public LeaveRequestNotFoundException(string text) : base(text)
    {
    }
}


internal class OverlappingLeaveException : EmployeeManagmentException
{
    public OverlappingLeaveException(string text) : base(text)
    {
    }
}

internal class NoSalaryFoundException : EmployeeManagmentException
{
    public NoSalaryFoundException(string text) : base(text)
    {
    }
}

internal class InvalidSalaryException : EmployeeManagmentException
{
    public InvalidSalaryException(string text) : base(text)
    {
    }
}
internal class InvalidLeaveDateException : EmployeeManagmentException
{
    public InvalidLeaveDateException(string text) : base(text)
    {
    }
}
internal class InvalidLeaveStatusException : EmployeeManagmentException
{
    public InvalidLeaveStatusException(string text) : base(text)
    {
    }
}
