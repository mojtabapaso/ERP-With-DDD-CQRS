using ERP.Domain.Common;
using ERP.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public DateTime BirthDate { get; set; }
    public EmployeePosition Position { get; set; } = EmployeePosition.None;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = default!;
}
