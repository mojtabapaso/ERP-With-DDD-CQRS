using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class Product :BaseEntity
{
    public string Name { get; set; } = default!;
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}
