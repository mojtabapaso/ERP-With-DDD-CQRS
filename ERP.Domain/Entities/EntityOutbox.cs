using ERP.Domain.Enums;

namespace ERP.Domain.Entities;

public class EntityOutbox
{
    public int Id { get; set; }
    public int EntityId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool Success { get; set; }
    public ActionType ActionType { get; set; } = ActionType.NONE;
}
