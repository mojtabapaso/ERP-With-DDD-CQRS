using ERP.Domain.Exceptions;

namespace ERP.Domain.ValueObjects;

public record BaseId
{
    public BaseId()
    {
        
    }
    public int Value { get; }
    public BaseId(int value)
    {
        if (value == null)
        {
            throw new BaseIdNullException();
        }
        Value = value;
    }
    public static implicit operator int(BaseId baseId) => baseId.Value;
    public static implicit operator BaseId(int baseId) => new BaseId(baseId);
}
