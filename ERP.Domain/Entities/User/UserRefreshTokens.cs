using ERP.Domain.Common;
using ERP.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Entities.User;

public class UserRefreshTokens:BaseEntity
{
    public UserRefreshTokens() : base(default!)
    {
    }

    public string UserName { get; set; }
	public string RefreshToken { get; set; }
	public bool IsActive { get; set; } = true;
}