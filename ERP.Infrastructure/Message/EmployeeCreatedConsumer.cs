using ERP.Application.Message;
using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Infrastructure.MongoDbConfig;
using MassTransit;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ERP.Infrastructure.Message;

public class EmployeeCreatedConsumer : IConsumer<EmployeeCreated>
{
    private readonly IMongoCollection<EmployeeCreated> _companies;

    public EmployeeCreatedConsumer(IMongoDatabase database)
    {
        _companies = database.GetCollection<EmployeeCreated>("CompanyAndUsers");
    }

    private async Task UpsertCompanyAndItsEmployee(EmployeeCreated employee, Guid companyId)
    {


      await _companies.InsertOneAsync(employee);
        //try
        //{
        //var client = new MongoClient("mongodb://127.0.0.1:27017");
        //var db = client.GetDatabase("ERP");
        //var coll = db.GetCollection<BsonDocument>("test");
        //await coll.InsertOneAsync(new BsonDocument("Hello", "World"));
  

        //}
        //catch (Exception ex)
        //{

        //    throw;
        //}
        //IMongoCollection<EmployeeReadModel> mongoCollection ;
        //mongoCollection.InsertOne(employee)


        //var filter = Builders<CompanyAndItsEmployeeReadModel>.Filter.Eq(c => c.Company.Id, companyId);

        //var update = Builders<CompanyAndItsEmployeeReadModel>.Update
        //    .AddToSet(c => c.Employees, employee)
        //    .Inc(c => c.Company.EmployeeCount, 1);

        //var options = new UpdateOptions { IsUpsert = true };
        //await _companies.UpdateOneAsync(filter, update, options);
    }

    public async Task Consume(ConsumeContext<EmployeeCreated> context)
    {
        await _companies.InsertOneAsync(context.Message);

        //var message = context.Message;
        //EmployeePosition employeePosition = (EmployeePosition)message.EmployeePosition;
        //DegreeLevel degreeLevel = (DegreeLevel)message.DegreeLevel;

        //var newEmployee = new EmployeeCreated
        //{
        //    //Id = message.EmployeeRowId,
        //    Name = $"{message.FirstName} {message.LastName}",
        //    NationalCode = message.NationalCode,
        //    BirthDateUtc = message.BirthDateUtc,
        //    EmployeePosition = employeePosition.ToString(),
        //    DegreeLevel = degreeLevel.ToString()
        //};
    
        //await UpsertCompanyAndItsEmployee(newEmployee, message.CompanyId);

        // اضافه کردن یا بروزرسانی Employee در Company مربوطه

        // TODO: اگر Projectionهای دیگه هم هست، اینجا فراخوانی کن
        // await RebuildAnotherProjection(newEmployee);
    }
}



public class EmployeeUpdatedConsumer : IConsumer<EmployeeUpdated>
{
    private readonly IMongoCollection<CompanyAndItsEmployeeReadModel> _companies;

    public EmployeeUpdatedConsumer(IMongoDatabase database)
    {
        _companies = database.GetCollection<CompanyAndItsEmployeeReadModel>("CompanyAndUsers");
    }

    private async Task UpdateEmployeeInCompany(EmployeeReadModel employee, Guid companyId)
    {
        var filter = Builders<CompanyAndItsEmployeeReadModel>.Filter.Eq(c => c.Company.Id, companyId);
            //&
                     //Builders<CompanyAndItsEmployeeReadModel>.Filter.ElemMatch(c => c.Employees, u => u.Id == employee.Id);

        // اگر Employee موجود باشه، داده‌ها بروزرسانی شود
        var update = Builders<CompanyAndItsEmployeeReadModel>.Update
            .Set(c => c.Employees[-1].Name, employee.Name)
            .Set(c => c.Employees[-1].NationalCode, employee.NationalCode)
            .Set(c => c.Employees[-1].BirthDateUtc, employee.BirthDateUtc)
            .Set(c => c.Employees[-1].EmployeePosition, employee.EmployeePosition)
            .Set(c => c.Employees[-1].DegreeLevel, employee.DegreeLevel);

        // اگر Employee تو آرایه نبود، AddToSet کنیم (Idempotency)
        var options = new UpdateOptions { IsUpsert = true };

        var result = await _companies.UpdateOneAsync(filter, update, options);

        if (result.MatchedCount == 0)
        {
            // Employee وجود نداشت → AddToSet
            var addFilter = Builders<CompanyAndItsEmployeeReadModel>.Filter.Eq(c => c.Company.Id, companyId);
            var addUpdate = Builders<CompanyAndItsEmployeeReadModel>.Update
                .AddToSet(c => c.Employees, employee)
                .Inc(c => c.Company.EmployeeCount, 1);

            await _companies.UpdateOneAsync(addFilter, addUpdate, options);
        }
    }

    public async Task Consume(ConsumeContext<EmployeeUpdated> context)
    {
        var message = context.Message;

        try
        {
            EmployeePosition employeePosition = (EmployeePosition)message.EmployeePosition;
            DegreeLevel? degreeLevel = message.DegreeLevel.HasValue ? (DegreeLevel)message.DegreeLevel.Value : (DegreeLevel?)null;

            var updatedEmployee = new EmployeeReadModel
            {
                //Id = message.EmployeeRowId,/
                Name = $"{message.FirstName} {message.LastName}",
                NationalCode = message.NationalCode,
                BirthDateUtc = message.BirthDateUtc,
                EmployeePosition = employeePosition.ToString(),
                DegreeLevel = degreeLevel?.ToString()
            };

            await UpdateEmployeeInCompany(updatedEmployee, message.CompanyId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error consuming EmployeeUpdated: {ex.Message}");
            throw; // اجازه بده MassTransit Retry یا DLQ مدیریت کنه
        }
    }
}


public class EmployeeDeletedConsumer : IConsumer<EmployeeDeleted>
{
    public async Task Consume(ConsumeContext<EmployeeDeleted> context)
    {
        var message = context.Message;

        // دسترسی به دیتا
        Console.WriteLine($"Employee deleted: Id {message.EmployeeId} ");

        // هر کاری که لازمه: ذخیره در DB, فراخوانی سرویس دیگه, ...
    }
}

