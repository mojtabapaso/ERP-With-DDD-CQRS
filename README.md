---

# DDD + CQRS .NET Project (SQL Server + MongoDB)

This is a modular and scalable .NET project based on **Domain-Driven Design (DDD)** and **CQRS**, using **SQL Server for write operations** and **MongoDB for read models**.
It goes beyond basic CRUD by applying solid architectural patterns and modern best practices for maintainable enterprise applications.

---

## ⚙️ Tech Stack

| Feature              | Technology / Pattern                                     |
| -------------------- | -------------------------------------------------------- |
| ORM                  | Entity Framework Core 8 (SQL Server)                     |
| NoSQL                | MongoDB Driver (Read DB)                                 |
| CQRS / Mediator      | MediatR                                                  |
| Validation           | FluentValidation                                         |
| Mapping              | AutoMapper                                               |
| Logging              | Serilog                                                  |
| Testing              | xUnit / NUnit + FluentAssertions                         |
| Background Sync      | HostedService (SQL → Mongo)                              |
| Dependency Injection | Built-in .NET DI Container                               |
| API Documentation    | Swagger (Swashbuckle)                                    |
| Exception Handling   | Custom Middleware                                        |
| Messaging            | Domain Events + Outbox Pattern                           |
| Design Patterns      | Specification, Factory, Repository, UoW, Aggregate, etc. |

---

## ✅ Features

* Clean, layered DDD structure (Domain, Application, Infrastructure, Presentation)
* Eventual consistency between SQL Server and MongoDB
* Global exception handling, CORS, HTTPS redirection, and rate limiting
* Soft delete implemented via global EF Core filters
* Full auditing (CreatedAt, ModifiedBy, etc.)
* Unit-tested domain and application layers with FluentAssertions

---

## 🧩 Automatic Repository Registration

The project includes an **automatic repository registration system** using a custom `AutoRegisterAttribute`.
Interfaces decorated with this attribute are automatically detected and registered in the dependency container via reflection, reducing manual configuration and keeping the codebase cleaner.

**Example:**

```csharp
[AutoRegister(ServiceLifetime.Scoped)]
public interface IEmployeeWriteRepository : IGenericWriteRepository<Employee> { }
```
