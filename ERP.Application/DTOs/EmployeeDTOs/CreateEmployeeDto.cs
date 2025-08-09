using ERP.Domain.Entities;
using ERP.Domain.Enums;

namespace ERP.Application.DTOs.EmployeeDTOs;

public sealed record CreateEmployeeDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public DateTime BirthDate { get; init; }
    public EmployeePosition EmployeePosition { get; init; }
    public int CompanyId { get; init; }
    public DegreeLevel? DegreeLevel { get; init; }
    //public Company Company { get; init; }

}
