using ERP.Application.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs.UserDTOs;

public class LoginDTO:BaseDTO
{
	[Required]
	public string UserName { get; set; }
	[Required]
	public string Password { get; set; }
}