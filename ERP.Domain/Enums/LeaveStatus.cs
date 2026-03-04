namespace ERP.Domain.Enums;

public enum LeaveStatus
{
    Pending = 1,      // در انتظار تایید
    Approved = 2,     // تایید شده
    Rejected = 3,     // رد شده
    Cancelled = 4,    // لغو شده
    Taken = 5        // استفاده شده
}
