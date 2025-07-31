using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class InvoiceItem : BaseEntity
{
    public InvoiceItem() : base(default!)
    {
    }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; }
    public long UnitPrice { get; set; }
}
