namespace ERP.Application.DTOs.EmployeeDTOs;

public class EmployeeDetailsDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public string Position { get; init; }
    public DateTime BirthDate { get; init; }
    public string DegreeLevel { get; init; }
    public List<SalaryDto> Salaries { get; init; }
}
