using Microsoft.AspNetCore.Identity;

namespace ERP.Domain.Entities.User;

public class ApplicationRole : IdentityRole<int>
{
    public Guid RowId { get; set; }
}

