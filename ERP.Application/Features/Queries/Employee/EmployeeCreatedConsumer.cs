using ERP.Application.Message;
using MassTransit;

namespace ERP.Application.Features.Queries.Employee;


public class EmployeeCreatedConsumer : IConsumer<EmployeeCreated>
{
    //private readonly IMongoDbService _mongoService;

    //public EmployeeCreatedConsumer(IMongoDbService mongoService)
    //{
    //    _mongoService = mongoService;
    //}

    public async Task Consume(ConsumeContext<EmployeeCreated> context)
    {
        var message = context.Message;

        // حالا می‌توانیم MongoDB را آپدیت کنیم
        //await _mongoService.InsertAsync(new EmployeeReadModel
        //{
        //    RowId = message.EmployeeRowId,
        //    EmployeeId = message.EmployeeId,
        //    FirstName = message.FirstName,
        //    LastName = message.LastName,
        //    NationalCode = message.NationalCode,
        //    BirthDateUtc = message.BirthDateUtc,
        //    EmployeePosition = message.EmployeePosition,
        //    CompanyId = message.CompanyId,
        //    DegreeLevel = message.DegreeLevel
        //});
    }
}
