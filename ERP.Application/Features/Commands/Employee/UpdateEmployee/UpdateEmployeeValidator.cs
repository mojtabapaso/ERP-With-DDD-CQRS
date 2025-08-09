namespace ERP.Application.Features.Commands.Employee.UpdateEmployee;

using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Domain.Enums;
using FluentValidation;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmpoyeeDto>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.RowId)
            .NotEmpty().WithMessage("RowId is required.");



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


        // DegreeLevel: optional, but if provided must be valid enum
        When(x => x.DegreeLevel.HasValue, () =>
        {
            RuleFor(x => x.DegreeLevel.Value)
                .IsInEnum().WithMessage("Degree level is invalid.");
        });
    }
}
