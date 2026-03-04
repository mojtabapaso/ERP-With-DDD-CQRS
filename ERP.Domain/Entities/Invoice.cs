using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Invoice : BaseEntity
{
    public Invoice() : base()
    {
    }

    // ───── Backing Fields ─────
    private DateTime _issueDate;
    private Customer _customer;
    private Guid _customerId;
    private IReadOnlyCollection<InvoiceItem> _items; // or IReadOnlyCollection ||  ICollection || even LinkedList
    // ───── Public Read-Only Properties ─────
    public DateTime IssueDate => _issueDate;
    public Guid CustomerId => _customerId;
    public Customer Customer => _customer;
    public IReadOnlyCollection<InvoiceItem> Items => _items;
    public long TotalAmount => Items.Sum(x => x.Quantity * x.UnitPrice);
}
