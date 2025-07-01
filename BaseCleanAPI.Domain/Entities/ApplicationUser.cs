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

