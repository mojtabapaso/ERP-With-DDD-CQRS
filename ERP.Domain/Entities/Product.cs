using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Entities;

public class Product :BaseEntity
{
    public Product() : base(default!)
    {
    }

    public NameValueObject Name { get; private set; } = default!;
    public SKUValueObject SKU { get; private set; } = default!;
    public MoneyValueObject Price { get; private set; } = default!;
    public AmountValueObject QuantityInStock { get; private set; } = default!;


    public void IncreaseStock(AmountValueObject amount)
    {
        QuantityInStock += amount;
    }

    public void ReduceStock(AmountValueObject amount)
    {
        QuantityInStock -= amount;
    }
    public void ChangeSKU(SKUValueObject newSku)
    {
        SKU = newSku;
    }
} 
