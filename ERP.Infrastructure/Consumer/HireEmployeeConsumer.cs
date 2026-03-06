using ERP.Domain.Entities;
using ERP.Domain.Events.EmployeeManagment;
using ERP.Domain.Repository.EmployeeManagment;
using MassTransit;
using MongoDB.Driver;

namespace ERP.Infrastructure.Message;

// need go to application layer

// or HireEmployeeEventHandler
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
        EmployeeHiredEvent hireEmployeeMessage = context.Message;
        var employee = await employeeWriteRepository.GetEmployeeReadModelByEmployeeRowId(hireEmployeeMessage.employeeId);
        await collection.InsertOneAsync(employee);
    }
}