using ERP.Domain.Entities;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Infrastructure.Generic;
using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repository.EmployeeManagment;

public class EmployeeWriteRepository : GenericWriteRepository<Employee>, IEmployeeWriteRepository
{
    private readonly WriteDbContext context;

    public EmployeeWriteRepository(WriteDbContext context) : base(context)
    {
        this.context = context;
    }
    public async Task<EmployeeReadModel> GetEmployeeReadModelByEmployeeId(int Id)
    {
        EmployeeReadModel employeeReadModel = await context.Employees
            .AsNoTracking()
            .Include(c => c.Company)
            .Where(e => e.Id == Id)
            .Select(e => new EmployeeReadModel
            {
                EmployeeId = e.RowId,
                Name = e.FullName,
                NationalCode = e.NationalCode,
                BirthDateUtc = e.BirthDateUtc,
                EmployeePosition = e.EmployeePosition.ToString(),
                DegreeLevel = e.DegreeLevel.ToString(),
                CompanyId = e.Company.RowId,
                CompanyName = e.Company.Name
            }).FirstOrDefaultAsync();

        return employeeReadModel;
    }
}

public class CompanyWriteRepository : GenericWriteRepository<Company>, ICompanyWriteRepository
{
    public CompanyWriteRepository(WriteDbContext context) : base(context) { }


}
