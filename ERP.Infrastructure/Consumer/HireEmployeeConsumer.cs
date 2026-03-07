using ERP.Domain.Entities;
using ERP.Domain.Events.EmployeeManagment;
using ERP.Domain.Repository.EmployeeManagment;
using MassTransit;
using MongoDB.Driver;

namespace ERP.Infrastructure.Message;

// change to  EmployeeHireEventHandler
public class HireEmployeeConsumer : IConsumer<EmployeeHiredEvent>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly IMongoCollection<EmployeeReadModel> collection;

    public HireEmployeeConsumer(IEmployeeWriteRepository employeeWriteRepository, IMongoDatabase mongoDatabase)
    {
        this.employeeWriteRepository = employeeWriteRepository;
        this.collection = mongoDatabase.GetCollection<EmployeeReadModel>("Employee");
    }
    public async Task Consume(ConsumeContext<EmployeeHiredEvent> context)
    {
        var employee = await employeeWriteRepository.GetEmployeeReadModelByEmployeeRowId(context.Message.employeeId);
        await collection.InsertOneAsync(employee);
    }
}