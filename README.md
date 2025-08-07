#  DDD + CQRS .NET Project (SQL Server + MongoDB)

This is a modular and scalable .NET project based on **Domain-Driven Design (DDD)** and **CQRS**, using **SQL Server for write operations** and **MongoDB for read models**. Built to go beyond simple CRUD, it applies solid architectural patterns and best practices.

---

## ⚙️ Tech Stack

| Feature            | Technology / Pattern                                       |
|--------------------|------------------------------------------------------------|
| ORM                | Entity Framework Core 8 (SQL Server)                       |
| NoSQL              | MongoDB Driver (Read DB)                                   |
| CQRS / Mediator    | MediatR                                                    |
| Validation         | FluentValidation                                           |
| Mapping            | AutoMapper                                                 |
| Logging            | Serilog                                                    |
| Testing            | xUnit / NUnit + FluentAssertions                          |
| Background Sync    | HostedService (SQL → Mongo)                                |
| DI                 | Built-in Dependency Injection                              |
| API Doc            | Swagger (Swashbuckle)                                      |
| Exception Handling | Custom Middleware                                          |
| Messaging          | Domain Events + Outbox Pattern                             |
| Design Patterns    | Specification, Factory, Repository, UoW, Aggregate, etc.   |

---

## ✅ Features

- Clean DDD structure (Domain, Application, Infrastructure, Presentation)
- Eventual consistency between SQL Server and MongoDB
- Global exception handling, CORS, HTTPS redirection, rate limiting
- Soft delete with global EF filters
- Full auditing (CreatedAt, ModifiedBy, etc.)
- Unit tested core logic with FluentAssertions

---


dotnet ef database update
dotnet run --project YourProject.Presentation
