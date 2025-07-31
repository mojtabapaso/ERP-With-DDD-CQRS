using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Factories.EmployeeManagment;

public class EmployeeFactory : IEmployeeFactory
{
    public Employee Create(
         FirstName firstName,
         LastName lastName,
         NationalCode nationalCode,
         BirthDate birthDateUtc,
         EmployeePosition employeePosition,
         int companyId,
         Company company)
    {
        var employee = new Employee(
            firstName,
            lastName,
            nationalCode,
            birthDateUtc,
            employeePosition,
            companyId,
            company);

        return employee;
    }
    public Employee Create( FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId)
    {
        var newCompony = new Company();
        return new Employee( firstName, lastName, nationalCode, birthDateUtc, employeePosition, companyId, newCompony);
    }
}
