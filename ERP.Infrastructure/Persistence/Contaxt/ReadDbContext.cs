using ERP.Domain.Entities;
using ERP.Infrastructure.MongoDbConfig;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace ERP.Infrastructure.Persistence.Contaxt;

internal sealed class ReadDbContext
{
    private readonly IMongoDatabase database;

    public ReadDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["ConnectionStrings:ConnectionRead"]);
        database = client.GetDatabase(configuration["ConnectionStrings:ReadDatabaseName"]);
    }

    public IMongoCollection<CompanyAndItsEmployeeReadModel> CompanyAndItsUsersReports => database.GetCollection<CompanyAndItsEmployeeReadModel>(nameof(CompanyAndItsUsersReports));
    public IMongoCollection<EmployeeReadModel> Employees => database.GetCollection<EmployeeReadModel>("Employees");
}
