using ERP.Shared.Abstraction.Exceptions;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions;

internal class InvalidNationalCodeException : EmployeeManagmentException
{
    public InvalidNationalCodeException(string res) : base(res)
    {
    }
}

internal class InvalidEmailException : EmployeeManagmentException
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}
internal class InvalidPhoneNumberException :  EmployeeManagmentException
{
    public InvalidPhoneNumberException(string message) : base(message)
    {

    }
}


internal class InvalidMoneyValueException : EmployeeManagmentException
{
    public InvalidMoneyValueException(string message) : base(message)
    {
    }
}