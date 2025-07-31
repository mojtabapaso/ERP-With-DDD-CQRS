using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Commmand;

namespace ERP.Application.Features.Commands.Employee.CreateEmployee;
public sealed record CreateEmployeeCommand( FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDate, EmployeePosition employeePosition, int companyId, Company company) : ICommand;
