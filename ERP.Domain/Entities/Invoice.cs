using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Invoice : BaseEntity
{
    public Invoice() : base(default!)
    {
    }

    public DateTime IssueDate { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public long TotalAmount => Items.Sum(x => x.Quantity * x.UnitPrice);
}
