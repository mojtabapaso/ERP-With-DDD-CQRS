using ERP.Domain.AggregateRoots;
using ERP.Domain.Common;
using ERP.Domain.DomainEvents;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Domain;
using System.ComponentModel.Design;

namespace ERP.Domain.Entities;

public class Employee : AggregateRoot<Employee>
{
    // ───── Backing Fields ─────
    private FirstName _firstName;
    private LastName _lastName;
    private NationalCode _nationalCode;
    private BirthDate _birthDateUtc;
    private EmployeePosition _employeePosition;
    private int _companyId;
    private Company _company;
    private LinkedList<EmployeeSalary> _employeeSalary = new();
    private DegreeLevel? _degreeLevel;

    // ───── Public Read-Only Properties ─────
    public FirstName FirstName => _firstName;
    public LastName LastName => _lastName;
    public NationalCode NationalCode => _nationalCode;
    public BirthDate BirthDateUtc => _birthDateUtc;
    public EmployeePosition EmployeePosition => _employeePosition;
    public int CompanyId => _companyId;
    public Company? Company => _company;
    public IReadOnlyCollection<EmployeeSalary> EmployeeSalaries => _employeeSalary;
    public DegreeLevel? DegreeLevel => _degreeLevel;
    public Employee() : base() { }

    //public Employee(BaseId id) : base(id) { }

    //private protected Employee(FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, Company company, DegreeLevel? degreeLevel) : base()
    //{

    //    _firstName = firstName;
    //    _lastName = lastName;
    //    _nationalCode = nationalCode;
    //    _birthDateUtc = birthDateUtc;
    //    _employeePosition = employeePosition;
    //    _companyId = companyId;
    //    _company = company;
    //    //_employeeSalary = employeeSalary;
    //    _degreeLevel = degreeLevel;
    //    //CreateEmployee() 
    //}
    private Employee(FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, DegreeLevel? degreeLevel)
    {
        _firstName = firstName; _lastName = lastName; _nationalCode = nationalCode; _birthDateUtc = birthDateUtc; _employeePosition = employeePosition; _companyId = companyId; _degreeLevel = degreeLevel;
    }
    public Employee Create(FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, DegreeLevel degreeLevel)
    {
        var employee = new Employee(
            firstName,
            lastName,
            nationalCode,
            birthDateUtc,
            employeePosition,
            companyId,
        degreeLevel
            );
        RaiseEventEvent(new NewEmployeeCreated(employee.RowId, employee.FirstName, employee.LastName, employee.CompanyId));
        return employee;
    }
    public void Update(FirstName firstName,
        LastName lastName,
        NationalCode nationalCode,
        BirthDate birthDateUtc,
        EmployeePosition employeePosition,
        int companyId,
        DegreeLevel? degreeLevel)
    {
        _firstName = firstName;
        _lastName = lastName;
        _nationalCode = nationalCode;
        _birthDateUtc = birthDateUtc;
        _employeePosition = employeePosition;
        _companyId = companyId;
        _degreeLevel = degreeLevel;
    }
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
