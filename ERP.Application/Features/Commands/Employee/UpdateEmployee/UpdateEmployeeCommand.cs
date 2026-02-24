using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Commmand;
using ERP.Shared.Common.ResultPattern;
using MediatR;
namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

public record UpdateEmployeeCommand(RowIdValueObject rowId, DateTime? updatedAt, FirstName firstName, LastName lastName, NationalCode nationalCode, BirthDate birthDateUtc, EmployeePosition employeePosition, int companyId, Company company,DegreeLevel DegreeLevel) : IRequest<Result<string>>;
