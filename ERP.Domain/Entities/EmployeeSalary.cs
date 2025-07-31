using ERP.Domain.Common;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class EmployeeSalary : BaseEntity
{
    public EmployeeSalary() : base(default!)
    {
    }
    private Amount _amount;
    // Employee reference
    private BaseId _employeeId;
    // Salary period (month/year)
    private DateTime _periodStart;
    private DateTime _periodEnd;

    // Salary components
    private Amount _basicSalary;
    private Amount _allowances;
    private Amount _deductions;
    private Amount _bonuses;

    // Tax information
    private Amount _taxAmount;

    // Payment status
    private SalaryPaymentStatus _paymentStatus;

    // Payment date (when actually paid)
    private DateTime? _paymentDate;

    // Net salary (calculated)
    public Amount NetSalary
    {
        get { return _basicSalary + _allowances + _bonuses - _deductions - _taxAmount; }
    }

    // Methods to update salary components
    public void UpdateBasicSalary(Amount newAmount)
    {
        _basicSalary = newAmount;
        UpdateModifiedDate();
    }

    public void AddAllowance(Amount allowance)
    {
        _allowances += allowance;
        UpdateModifiedDate();
    }

    public void AddDeduction(Amount deduction)
    {
        _deductions += deduction;
        UpdateModifiedDate();
    }

    public void MarkAsPaid(DateTime paymentDate)
    {
        _paymentStatus = SalaryPaymentStatus.Paid;
        _paymentDate = paymentDate;
        UpdateModifiedDate();
    }

    private void UpdateModifiedDate()
    {
        // This would update the UpdatedAt field from BaseEntity
        // Implementation depends on your BaseEntity implementation
    }
}


// Assuming these types are defined elsewhere in your project:
// public record EmployeeId(Guid Value);
// public record Amount(decimal Value, string Currency);