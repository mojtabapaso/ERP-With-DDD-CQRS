﻿using Microsoft.AspNetCore.Identity;

namespace ERP.Domain.Entities;

public class ApplicationUser : IdentityUser
{
	public string? RefreshToken { get; set; }
	public DateTime RefreshTokenExpiryTime { get; set; }
}
