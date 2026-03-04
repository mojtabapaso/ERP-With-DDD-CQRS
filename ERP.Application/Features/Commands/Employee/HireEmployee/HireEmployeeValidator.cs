using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Domain.Enums;
using FluentValidation;

namespace ERP.Application.Features.Commands.Employee.HireEmployee;

public class HireEmployeeValidator : AbstractValidator<HireEmployeeDto>
{
    public HireEmployeeValidator()
    {
        // NationalCode: optional, but if provided must be valid
        When(x => !string.IsNullOrEmpty(x.NationalCode), () =>
        {
            RuleFor(x => x.NationalCode)
                .Length(10).WithMessage("National code must be exactly 10 characters.")
                .Matches("^[0-9]*$").WithMessage("National code must contain only digits.");
        });

        // BirthDate: optional, but if provided must be valid
        When(x => x.BirthDate != default(DateTime), () =>
        {
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now).WithMessage("Birth date must be in the past.");
        });

        // EmployeePosition: optional, but if provided must be valid enum
        When(x => Enum.IsDefined(typeof(EmployeePosition), x.EmployeePosition), () =>
        {
            RuleFor(x => x.EmployeePosition)
                .IsInEnum().WithMessage("Employee position is invalid.");
        });

        RuleFor(x => x.CompanyId).NotNull().NotEmpty().WithMessage("Company Id required");

    }
}
