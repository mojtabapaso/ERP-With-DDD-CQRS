using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.AggregateRoots;

public class EmployeeAggregateRoot
{
    // *.AggregateRoot
    // 1.Employee
    // 2.LeaveRequest
    // 3.EmployeeSalary
    private static Employee _employee { get; set; } = new Employee();
    private static EmployeeSalary _employeeSalary { get; set; } = new EmployeeSalary();
    private readonly List<LeaveRequest> _leaveRequests = new(); 
    public IReadOnlyCollection<LeaveRequest> LeaveRequests => _leaveRequests.AsReadOnly();
    public static Employee HireNewEmployee(FirstName firstName, LastName lastName, NationalCode nationalCode,
                                BirthDate birthDateUtc, EmployeePosition position, int companyId,
                                DegreeLevel? degreeLevel, MoneyValueObject salary)
    {
        var result = _employee.Hire(firstName, lastName, nationalCode, birthDateUtc, position, companyId, degreeLevel, salary);
        return result;
    }

}

