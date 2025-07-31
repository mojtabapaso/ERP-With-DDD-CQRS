namespace ERP.Application.DTOs.EmployeeDTOs;

public class EmployeeDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public DateTime BirthDate { get; init; }
    public string EmployeePosition { get; init; }
    public string CompanyName { get; init; }
    public string DegreeLevel { get; init; }
    public List<SalaryDto> Salaries { get; init; }
}
