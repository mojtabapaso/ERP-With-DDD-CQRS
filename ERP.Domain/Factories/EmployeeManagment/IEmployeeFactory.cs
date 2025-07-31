using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Factories.EmployeeManagment;

public interface IEmployeeFactory
{
    Employee Create( FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, Company company);
}
