using AutoMapper;
using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Shared.Common.ResultPattern;
using MediatR;

namespace ERP.Application.Features.Queries.Employee.GetEmployeeByRowId;

public sealed class GetEmployeeByRowIdQueryHandler : IRequestHandler<GetEmployeeByRowIdQuery, Result<EmployeeDto>>
{
    private readonly IEmployeeReadRepository employeeReadRepository;
    private readonly IMapper mapper;

    public GetEmployeeByRowIdQueryHandler(IEmployeeReadRepository employeeReadRepository, IMapper mapper)
    {
        this.employeeReadRepository = employeeReadRepository;
        this.mapper = mapper;
    }

    public async Task<Result<EmployeeDto>> Handle(GetEmployeeByRowIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeReadRepository.GetByRowIdAsync(request.RowId, cancellationToken);

        if (employee is null)
            return Result<EmployeeDto>.Error();

        var dto = mapper.Map<EmployeeDto>(employee);
        return Result<EmployeeDto>.Success(dto);
    }
}

