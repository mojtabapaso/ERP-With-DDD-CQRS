using ERP.Application.Configurations;
using ERP.Application.Message;
using ERP.Infrastructure.Message;
using ERP.Infrastructure.Persistence.Contaxt;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;


namespace ERP.Infrastructure.IocConfig;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ReadDbContext>();

        // 1. Bind config sections
        //services.Configure<AzureAdSettings>(
        //    configuration.GetSection("AzureAd"));
        //services.Configure<JwtSettings>(
        //    configuration.GetSection("Jwt"));
        services.Configure<ConnectionStringsSettings>(
            configuration.GetSection("ConnectionStrings"));

        // 2. DbContext registration (مثال)
        //var conn = configuration
        //    .GetSection("ConnectionStrings")
        //    .Get<ConnectionStringsSettings>()
        //    .ConnectionWrite;
        //services.AddDbContext<EFCore.AppDbContext>(opt =>
        //    opt.UseSqlServer(conn));

        // 3. هر سرویس دیگری مثل MediatR, Identity, Caching و…
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(...));
        //services.AddMassTransit(x =>
        //{
        //    x.UsingRabbitMq((context, cfg) =>
        //    {
        //        cfg.Host("rabbitmq://localhost");
        //    });
        //});
        //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("ERP");
        services.AddSingleton(mongoDatabase);
 
        services.AddMassTransit(x =>
        {
            // Consumers
            x.AddConsumer<EmployeeCreatedConsumer>();
            x.AddConsumer<EmployeeUpdatedConsumer>();
            x.AddConsumer<EmployeeDeletedConsumer>();
            // Transport
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost");

                cfg.ConfigureEndpoints(context);
            });

            // Outbox روی EF Core
            x.AddEntityFrameworkOutbox<WriteDbContext>(o =>
            {
                // Outbox پیام‌ها رو توی همون Transaction دیتابیس ذخیره می‌کنه
                o.QueryDelay = TimeSpan.FromSeconds(1); // هر چند وقت یک بار چک کنه
                o.UseSqlServer(); // یا UsePostgres, UseMySql و غیره
                o.DisableInboxCleanupService(); // اگه cleanup نمی‌خوای
            });
        });





        return services;
    }
}

public record EntityChangedIntegrationEvent
{
    public string EntityName { get; init; } = string.Empty;
    public EntityState State { get; init; } = EntityState.Unchanged;
    public Dictionary<string, object?> OldValues { get; init; } = new();
    public Dictionary<string, object?> NewValues { get; init; } = new();
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}

public class GenericEntityEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public GenericEntityEventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(EntityChangedIntegrationEvent evt)
    {
        await _publishEndpoint.Publish(evt);
    }
}

//public static class DbContextExtensions
//{
//    public static async Task PublishEntityChangesAsync(this DbContext context, IPublishEndpoint publisher)
//    {
//        context.ChangeTracker.DetectChanges();

//        foreach (var entry in context.ChangeTracker.Entries())
//        {
//            if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
//                continue;

//            var evt = new EntityChangedIntegrationEvent
//            {
//                EntityName = entry.Entity.GetType().Name,
//                State = entry.State,
//            };

//            foreach (var prop in entry.Properties)
//            {
//                if (prop.IsTemporary) continue;

//                switch (entry.State)
//                {
//                    case EntityState.Added:
//                        evt.NewValues[prop.Metadata.Name] = prop.CurrentValue;
//                        break;
//                    case EntityState.Deleted:
//                        evt.OldValues[prop.Metadata.Name] = prop.OriginalValue;
//                        break;
//                    case EntityState.Modified:
//                        if (prop.IsModified)
//                        {
//                            evt.OldValues[prop.Metadata.Name] = prop.OriginalValue;
//                            evt.NewValues[prop.Metadata.Name] = prop.CurrentValue;
//                        }
//                        break;
//                }
//            }

//            await publisher.Publish(evt);
//        }
//    }
//}

//public class GenericEntityConsumer : IConsumer<EntityChangedIntegrationEvent>
//{
//    private readonly IMongoDatabase _database;

//    public GenericEntityConsumer(IMongoDatabase database)
//    {
//        _database = database;
//    }

//    public async Task Consume(ConsumeContext<EntityChangedIntegrationEvent> context)
//    {
//        var evt = context.Message;
//        var collection = _database.GetCollection<BsonDocument>(evt.EntityName);

//        var doc = evt.NewValues.Count > 0 ? evt.NewValues.ToBsonDocument() : evt.OldValues.ToBsonDocument();

//        switch (evt.State)
//        {
//            case EntityState.Added:
//                await collection.InsertOneAsync(doc);
//                break;
//            case EntityState.Modified:
//                var filter = Builders<BsonDocument>.Filter.Eq("_id", doc["_id"]);
//                await collection.ReplaceOneAsync(filter, doc);
//                break;
//            case EntityState.Deleted:
//                var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", doc["_id"]);
//                await collection.DeleteOneAsync(deleteFilter);
//                break;
//        }
//    }
//}
