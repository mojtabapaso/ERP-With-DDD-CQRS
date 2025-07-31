using Microsoft.EntityFrameworkCore;
using ERP.Infrastructure.Persistence.Models.EmployeeManagment;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace ERP.Infrastructure.Persistence.Contaxt;

internal sealed class ReadDbContext
{
    private readonly IMongoDatabase database;

    public ReadDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
        database = client.GetDatabase(configuration["MongoDb:Database"]);
    }

    // مثال: دسترسی به کالکشن‌ها
    public IMongoCollection<EmployeeReadModel> Employees => database.GetCollection<EmployeeReadModel>("Employees");
}
