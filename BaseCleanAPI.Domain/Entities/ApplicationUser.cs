using Microsoft.AspNetCore.Identity;

namespace ERP.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
	public Guid RowId { get; set; }
}

public class ApplicationRole : IdentityRole<int>
{
	public Guid RowId { get; set; }
}

public class UserRefreshToken
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string RefreshToken { get; set; } = default!;
    public DateTime ExpiryTime { get; set; }
}
