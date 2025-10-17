using ERP.Infrastructure.MongoDbConfig;
using ERP.Infrastructure.Persistence.Models.EmployeeManagment;
using Microsoft.EntityFrameworkCore;
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
