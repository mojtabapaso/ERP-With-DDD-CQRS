using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Product :BaseEntity
{
    public Product() : base(default!)
    {
    }

    public string Name { get; set; } = default!;
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}
