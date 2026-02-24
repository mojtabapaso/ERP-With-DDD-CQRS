using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Factories.EmployeeManagment;

//public class EmployeeFactory : IEmployeeFactory
//{
//    public Employee Create(
//         FirstName firstName,
//         LastName lastName,
//         NationalCode nationalCode,
//         BirthDate birthDateUtc,
//         EmployeePosition employeePosition,
//         int companyId,
//         Company company,
//        DegreeLevel? degreeLevel
//        )
//    {
//        var employee = new Employee(
//            firstName,
//            lastName,
//            nationalCode,
//            birthDateUtc,
//            employeePosition,
//            companyId,
//            company, degreeLevel
//            );

//        return employee;
//    }
//    public Employee Create(FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, DegreeLevel? degreeLevel)
//    {
//        var newCompony = new Company();
//        return new Employee(firstName, lastName, nationalCode, birthDateUtc, employeePosition, companyId, newCompony, degreeLevel);
//    }
//}
