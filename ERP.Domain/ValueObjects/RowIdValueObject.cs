using ERP.Domain.Exceptions;

namespace ERP.Domain.ValueObjects;

public record RowIdValueObject
{
    public Guid Value { get; }
    public RowIdValueObject(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new RowIdNullException();
        }
        Value = value;
    }
    public static implicit operator Guid(RowIdValueObject rowId) => rowId.Value;
    public static implicit operator RowIdValueObject(Guid rowId) => new RowIdValueObject(rowId);
}
