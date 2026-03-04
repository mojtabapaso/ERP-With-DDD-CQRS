using ERP.Domain.Common;
using ERP.Domain.Enums;
using ERP.Domain.Exceptions.EmployeeManagmentExceptions;

namespace ERP.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public int EmployeeId { get; private set; }
    public Employee Employee { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public LeaveType Type { get; private set; } // Annual, Sick, Emergency, etc.
    public LeaveStatus Status { get; private set; }
    public string Reason { get; private set; }
    public string? RejectionReason { get; private set; }
    public int TotalDays => (EndDate - StartDate).Days + 1;

    // برای ردیابی تاریخ اقدام
    public DateTime RequestedAt { get; private set; }
    public DateTime? ReviewedAt { get; private set; }
    public int? ReviewedBy { get; private set; } // UserId

    private LeaveRequest() : base() { } // برای EF Core

    public LeaveRequest(int employeeId, DateTime startDate, DateTime endDate,
        LeaveType type,string reason)
    {
        if (startDate > endDate)
            throw new InvalidLeaveDateException("Start date cannot be after end date");

        if (startDate < DateTime.UtcNow.Date)
            throw new InvalidLeaveDateException("Cannot request leave for past dates");

        EmployeeId = employeeId;
        StartDate = startDate;
        EndDate = endDate;
        Type = type;
        Reason = reason;
        Status = LeaveStatus.Pending;
        RequestedAt = DateTime.UtcNow;
    }
    public void Approve(int approverId)
    {
        if (Status != LeaveStatus.Pending)
            throw new InvalidLeaveStatusException("Only pending requests can be approved");

        Status = LeaveStatus.Approved;
        ReviewedAt = DateTime.UtcNow;
        ReviewedBy = approverId;
    }
    public void Reject(string rejectionReason, int approverId)
    {
        if (Status != LeaveStatus.Pending)
            throw new InvalidLeaveStatusException("Only pending requests can be rejected");

        Status = LeaveStatus.Rejected;
        RejectionReason = rejectionReason;
        ReviewedAt = DateTime.UtcNow;
        ReviewedBy = approverId;
    }
    public void Cancel()
    {
        if (Status == LeaveStatus.Approved && StartDate <= DateTime.UtcNow)
            throw new InvalidLeaveStatusException("Cannot cancel approved leave that has already started");

        Status = LeaveStatus.Cancelled;
    }
}
