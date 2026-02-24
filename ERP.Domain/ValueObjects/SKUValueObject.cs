using ERP.Domain.Exceptions.ProductManagment;
using ERP.Domain.ValueObjects.Base;

namespace ERP.Domain.ValueObjects;

public record SKUValueObject : StringValueObject
{
    public SKUValueObject(string value) : base(Normalize(value), nameof(SKUValueObject))
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            throw new InvalidSKUException("SKU is too short or invalid.");
    }

    private static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;

        return value
            .Trim()                     
            .Replace(" ", "-")         
            .ToUpperInvariant();     
    }

    public static implicit operator SKUValueObject(string value) => new SKUValueObject(value);
    public static implicit operator string(SKUValueObject value) => value.Value;
}