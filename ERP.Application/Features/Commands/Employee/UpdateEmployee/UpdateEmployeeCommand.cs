using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Commmand;
namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public record UpdateEmployeeCommand(BaseId id, RowId rowId, bool isDeleted, DateTime? createdAt, DateTime? updatedAt, FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, Company company) : ICommand;
