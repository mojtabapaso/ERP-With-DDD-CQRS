using ERP.Domain.Exceptions;

namespace ERP.Domain.ValueObjects;

public record RowId
{
    public Guid Value { get; }
    public RowId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new RowIdNullException();
        }
        Value = value;
    }
    public static implicit operator Guid(RowId rowId) => rowId.Value;
    public static implicit operator RowId(Guid rowId) => new RowId(rowId);
}
