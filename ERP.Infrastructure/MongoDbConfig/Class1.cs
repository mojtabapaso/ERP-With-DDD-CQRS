using MassTransit;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ERP.Infrastructure.MongoDbConfig;

public class EmployeeReadModel
{
    public Guid Id { get; set; }           
    public string Name { get; set; }        
    public string NationalCode { get; set; }  
    public DateTime BirthDateUtc { get; set; }
    public string EmployeePosition { get; set; }
    public string? DegreeLevel { get; set; }   
}

public class CompanyReadModel
{
    public Guid Id { get; set; }              
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TaxCode { get; set; }
    public int EmployeeCount { get; set; }
}


public class CompanyAndItsEmployeeReadModel
{
    public IList<EmployeeReadModel> Employees { get; set; } = new List<EmployeeReadModel>();
    public CompanyReadModel Company { get; set; }
}
