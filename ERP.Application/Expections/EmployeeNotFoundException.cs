using ERP.Shared.Abstraction.Exceptions;

public class EmployeeNotFoundException : EmployeeManagmentException
{
    public EmployeeNotFoundException() : base("Employee not found.")
    {
    }
}
