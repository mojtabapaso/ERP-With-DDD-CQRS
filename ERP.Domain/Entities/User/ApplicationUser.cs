using Microsoft.AspNetCore.Identity;

namespace ERP.Domain.Entities.User;

public class ApplicationUser : IdentityUser<int>
{
    public Guid RowId { get; set; }
}

