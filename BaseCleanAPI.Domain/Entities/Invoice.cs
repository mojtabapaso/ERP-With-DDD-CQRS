using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Invoice : BaseEntity
{

    public DateTime IssueDate { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public decimal TotalAmount => Items.Sum(x => x.Quantity * x.UnitPrice);
}
