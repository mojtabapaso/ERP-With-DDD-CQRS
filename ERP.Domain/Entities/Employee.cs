using ERP.Domain.AggregateRoots;
using ERP.Domain.Common;
using ERP.Domain.DomainEvents;
using ERP.Domain.Enums;
using ERP.Domain.Events.EmployeeManagment;
using ERP.Domain.Exceptions.EmployeeManagmentExceptions;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Employee : BaseEntity// : AggregateRoot<Employee>
{
    // Public CTOR for EF
    public Employee() 
    {
    }
    // Private CTOR 
    private Employee(FirstName firstName, LastName lastName,
                     NationalCode nationalCode, BirthDate birthDateUtc,
                     EmployeePosition employeePosition, int companyId,
                     DegreeLevel? degreeLevel)
    {
        _rowId = Guid.NewGuid();
        _firstName = firstName;
        _lastName = lastName;
        _nationalCode = nationalCode;
        _birthDateUtc = birthDateUtc;
        _employeePosition = employeePosition;
        _companyId = companyId;
        _degreeLevel = degreeLevel;
    }

    // ───── Backing Fields ─────
    private FirstName _firstName;
    private LastName _lastName;
    private NationalCode _nationalCode;
    private BirthDate _birthDateUtc;
    private EmployeePosition _employeePosition;
    private int _companyId;
    private Company _company;
    private LinkedList<EmployeeSalary> _salaries = new();
    private LinkedList<LeaveRequest> _leaveRequests = new();
    private DegreeLevel? _degreeLevel;
    private EmploymentStatus _employmentStatus;
    private DateTime? _terminationDate;
    private string? _terminationReason;

    // ───── Public Read-Only Properties ─────
    public FirstName FirstName => _firstName;
    public LastName LastName => _lastName;
    public string FullName => $"{_firstName} {_lastName}";
    public NationalCode NationalCode => _nationalCode;
    public BirthDate BirthDateUtc => _birthDateUtc;
    public EmployeePosition EmployeePosition => _employeePosition;
    public int CompanyId => _companyId;
    public Company? Company => _company;
    //public IReadOnlyCollection<EmployeeSalary> Salaries => _salaries;
    //public IReadOnlyCollection<LeaveRequest> LeaveRequests => _leaveRequests;
    public DegreeLevel? DegreeLevel => _degreeLevel;
    public EmploymentStatus EmploymentStatus => _employmentStatus;
    public DateTime? TerminationDate => _terminationDate;
    public string? TerminationReason => _terminationReason;
    public EmployeeSalary CurrentSalary => _salaries.LastOrDefault();

    //TODO
    // it's can be static & we don't need to create a inestance on *Mediat Handler* 
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
        //AddDomainEvent(new NewEmployeeCreated(employee.RowId, employee.FirstName, employee.LastName, employee.CompanyId));
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
    public  Employee Hire(FirstName firstName, LastName lastName, NationalCode nationalCode,
        BirthDate birthDateUtc, EmployeePosition position, int companyId, DegreeLevel? degreeLevel, MoneyValueObject salary)
    {
        var employee = new Employee(firstName, lastName, nationalCode, birthDateUtc, position, companyId, degreeLevel);
        employee.SetSalary(salary, DateTime.UtcNow);
        employee.AddDomainEvent(new EmployeeHiredEvent(employee.RowId));
        return employee;
    }

    public void TransferToCompany(Company newCompany, EmployeePosition newPosition)
    {
        if (_employmentStatus != EmploymentStatus.Active)
            throw new EmployeeNotActiveException("Cannot transfer non-active employee");

        var oldCompanyId = _companyId;
        _companyId = newCompany.Id;
        _company = newCompany;
        _employeePosition = newPosition;

        AddDomainEvent(new EmployeeTransferredEvent(
            RowId,
            oldCompanyId,
            newCompany.Id,
            newPosition));
    }

    // ۳. تغییر سمت
    //public void ChangePosition(EmployeePosition newPosition)
    //{
    //    if (_employmentStatus != EmploymentStatus.Active)
    //        throw new EmployeeNotActiveException("Cannot change position of non-active employee");

    //    var oldPosition = _employeePosition;
    //    _employeePosition = newPosition;

    //    AddDomainEvent(new EmployeePositionChangedEvent(
    //        Id,
    //        oldPosition,
    //        newPosition));
    //}

    //// ۴. ثبت حقوق
    public void SetSalary(MoneyValueObject amount, DateTime effectiveDate)
    {
        if (amount <= 0)
            throw new InvalidSalaryException("Salary must be greater than zero");

        // بررسی اینکه حقوق جدید از قبلی بیشتر باشد
        if (_salaries.Any() && amount <= _salaries.Last().NetSalary)
            throw new InvalidSalaryException("New salary must be greater than current salary");

        //var salary = new EmployeeSalary(amount, effectiveDate);
        //_salaries.AddLast(salary);

        //AddDomainEvent(new EmployeeSalarySetEvent(
        //    Id,
        //    amount,
        //    effectiveDate));
    }

    //// ۵. افزایش حقوق
    //public void IncreaseSalary(MoneyValueObject increaseAmount, string reason)
    //{
    //    if (_employmentStatus != EmploymentStatus.Active)
    //        throw new EmployeeNotActiveException("Cannot increase salary for non-active employee");

    //    if (_salaries.Count == 0)
    //        throw new NoSalaryFoundException("Employee has no salary record");

    //    var currentSalary = _salaries.Last().NetSalary;
    //    var newSalary = currentSalary + increaseAmount;

    //    SetSalary(newSalary, DateTime.UtcNow);

    //    AddDomainEvent(new EmployeeSalaryIncreasedEvent(
    //        Id,
    //        increaseAmount,
    //        reason));
    //}

    // ۶. مرخصی
    //public void RequestLeave(LeaveRequest leaveRequest)
    //{
    //    if (_employmentStatus != EmploymentStatus.Active)
    //        throw new EmployeeNotActiveException("Cannot request leave for non-active employee");

    //    // بررسی تداخل با مرخصی‌های قبلی
    //    //if (HasOverlappingLeave(leaveRequest))
    //    //    throw new OverlappingLeaveException("Leave request overlaps with existing leave");

    //    _leaveRequests.AddLast(leaveRequest);

    //    AddDomainEvent(new LeaveRequestedEvent(
    //        Id,
    //        leaveRequest.Id,
    //        leaveRequest.StartDate,
    //        leaveRequest.EndDate));
    //}

    //public void ApproveLeave(int leaveRequestId)
    //{
    //    var leave = _leaveRequests.FirstOrDefault(l => l.Id == leaveRequestId);
    //    if (leave == null)
    //        throw new LeaveRequestNotFoundException("Leave request not found");

    //    leave.Approve();

    //    AddDomainEvent(new LeaveApprovedEvent(AggregateId: RowId, Id, leaveRequestId));
    //}

    public void Terminate(string reason, DateTime terminationDate)
    {
        if (_employmentStatus != EmploymentStatus.Active)
            throw new EmployeeNotActiveException("Employee is already terminated");

        _employmentStatus = EmploymentStatus.Terminated;
        _terminationDate = terminationDate;
        _terminationReason = reason;

        AddDomainEvent(new EmployeeTerminatedEvent(
                AggregateId: RowId,     // Guid for Event Sourcing
                EmployeeId: Id,          // int for db relational
                FullName: FullName,
                Reason: reason,
                TerminationDate: terminationDate,
                CompanyId: _companyId
            ));
    }

    // ۸. استعفا
    public void Resign(DateTime resignationDate, string reason)
    {
        if (_employmentStatus != EmploymentStatus.Active)
            throw new EmployeeNotActiveException("Employee is already terminated");

        _employmentStatus = EmploymentStatus.Resigned;
        _terminationDate = resignationDate;
        _terminationReason = reason;

        AddDomainEvent(new EmployeeResignedEvent(
            AggregateId: RowId,
            Id,
            reason,
            resignationDate));
    }
}
