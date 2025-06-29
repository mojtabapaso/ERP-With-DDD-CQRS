using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Customer : BaseEntity
{
    public string FullName { get; set; } = default!;
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
