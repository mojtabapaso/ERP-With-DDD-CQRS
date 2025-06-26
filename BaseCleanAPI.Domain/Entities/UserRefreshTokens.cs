using ERP.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Entities;

public class UserRefreshTokens:BaseEntity
{
	public string UserName { get; set; }
	public string RefreshToken { get; set; }
	public bool IsActive { get; set; } = true;
}