using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Commands.Employee.CreateEmployee;
using FluentValidation;


namespace ERP.Application.Features.Employees.Commands.CreateEmployee;

//public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
//{
//    public CreateEmployeeCommandValidator()
//    {
//        RuleFor(x => x.firstName.Value)
//            .NotEmpty().NotNull().WithMessage("First name required");

//        RuleFor(x => x.nationalCode.Value)
//            .Length(10).WithMessage("National code must be 10 digits");

//        RuleFor(x => x.birthDate.Value)
//            .LessThan(DateTime.UtcNow).WithMessage("Invalid birth date");
//    }
//}


public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().NotNull().WithMessage("First name required");

        RuleFor(x => x.NationalCode)
            .Length(10).WithMessage("National code must be 10 digits");

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.UtcNow).WithMessage("Invalid birth date");

        RuleFor(x => x.CompanyId).NotNull().NotEmpty().WithMessage("Company Id required");
    }
}