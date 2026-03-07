using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MassTransit;
using MediatR;

namespace ERP.Application.Features.Commands.Employee.TransferToCompany;

public class TransferToCompanyCommandHandler : IRequestHandler<TransferToCompanyDto, Result<string>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly ICompanyWriteRepository companyWriteRepository;
    private readonly IPublishEndpoint publishEndpoint;

    public TransferToCompanyCommandHandler(IEmployeeWriteRepository employeeWriteRepository, ICompanyWriteRepository companyWriteRepository, IPublishEndpoint publishEndpoint)
    {
        this.employeeWriteRepository = employeeWriteRepository;
        this.companyWriteRepository = companyWriteRepository;
        this.publishEndpoint = publishEndpoint;
    }
    public async Task<Result<string>> Handle(TransferToCompanyDto request, CancellationToken cancellationToken)
    {
        var employee = await employeeWriteRepository.GetByRowIdAsync(request.EmployeeId);
        if (employee == null)
        {
            return Result<string>.Error("Employee not Found");
        }
        var company = await companyWriteRepository.GetByIdAsync(request.NewCompanyId);
        if (company == null)
        {
            return Result<string>.Error("Company not Found");
        }
        employee.TransferToCompany(company, request.EmployeePosition);

        await employeeWriteRepository.UpdateAsync(employee);

        return Result<string>.Success("ok");

    }
}