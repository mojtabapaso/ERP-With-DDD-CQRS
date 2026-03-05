using ERP.Application.Message;
using ERP.Domain.Entities;
using ERP.Domain.Repository.EmployeeManagment;
using MassTransit;
using MongoDB.Driver;

namespace ERP.Infrastructure.Message;

// need go to application layer

// or HireEmployeeEventHandler
public class HireEmployeeConsumer : IConsumer<HireEmployeeMessage>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly IMongoCollection<EmployeeReadModel> collection;

    public HireEmployeeConsumer(IEmployeeWriteRepository employeeWriteRepository, IMongoDatabase mongoDatabase)
    {
        this.employeeWriteRepository = employeeWriteRepository;
        this.collection = mongoDatabase.GetCollection<EmployeeReadModel>("Employee");
    }
    public async Task Consume(ConsumeContext<HireEmployeeMessage> context)
    {
        HireEmployeeMessage hireEmployeeMessage = context.Message;
        var employee = await employeeWriteRepository.GetEmployeeReadModelByEmployeeId(hireEmployeeMessage.EmployeeId.Value);
        collection.InsertOne(employee);
    }
}