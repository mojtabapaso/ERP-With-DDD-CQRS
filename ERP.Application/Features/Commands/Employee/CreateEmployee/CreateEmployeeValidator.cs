using ERP.Application.DTOs.EmployeeDTOs;
using FluentValidation;


namespace ERP.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().NotNull().WithMessage("First name required");
        RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Last name required");

        RuleFor(x => x.NationalCode)
            .Length(10).WithMessage("National code must be 10 digits");

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.UtcNow).WithMessage("Invalid birth date");

        RuleFor(x => x.CompanyId).NotNull().NotEmpty().WithMessage("Company Id required");
    }
}