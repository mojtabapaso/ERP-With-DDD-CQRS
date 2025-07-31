using ERP.Domain.Common;
using ERP.Domain.DomainEvents;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Domain;

namespace ERP.Domain.Entities;

public class Employee : BaseEntity

{
    private Employee() : base(default!) { }

    //public Employee(BaseId id) : base(id) { }
    public Employee(FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, Company company) : base(default!)
    {

        _firstName = firstName;
        _lastName = lastName;
        _nationalCode = nationalCode;
        _birthDateUtc = birthDateUtc;
        _employeePosition = employeePosition;
        _companyId = companyId;
        _company = company;
        RaiseEventEvent(new NewEmployeeCreated(this));
        //CreateEmployee() 
    }

    private FirstName _firstName;
    private LastName _lastName;
    private NationalCode _nationalCode;
    private BirthDate _birthDateUtc;
    private EmployeePosition _employeePosition;
    private int _companyId;
    private Company _company;
    private LinkedList<EmployeeSalary> _employeeSalary;
    private DegreeLevel _degreeLevel;


    // Domain Activity simple for test
    //internal void RemoveCompanyFromEmployee(Employee employee)
    //{
    //    var companyEmployee = _company.Employees.SingleOrDefault(employee);
    //    if (companyEmployee == null)
    //    {
    //        throw new CompanyEmployeeNullException();
    //    }
    //}
}
