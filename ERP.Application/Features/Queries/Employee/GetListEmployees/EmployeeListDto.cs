namespace ERP.Application.Features.Queries.Employee.GetListEmployees;

public class EmployeeListDto
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Position { get; init; }
    public string CompanyName { get; init; }
}
