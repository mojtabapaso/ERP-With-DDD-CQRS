using Asp.Versioning;
using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Commands.Employee.CreateEmployee;
using ERP.Application.Features.Commands.Employee.HireEmployee;
using ERP.Application.Features.Commands.Employee.SoftDelete;
using ERP.Application.Features.Commands.Employee.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Presentation.Controllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator mediator;

    public EmployeeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Employee")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto createEmployee)
    {
        var res = await mediator.Send(new CreateEmployeeRequest() { CreateEmployeeDto = createEmployee });
        if (!res.IsSuccess)
        {
            return BadRequest(res);
        }
        return Ok(res);
    }
    [HttpPatch("Employee")]
    public async Task<IActionResult> Update([FromBody] UpdateEmpoyeeDto updateEmployee)
    {
        var res = await mediator.Send(new UpdateEmployeeRequest() { UpdateEmpoyeeDto = updateEmployee });
        if (!res.IsSuccess)
        {
            return BadRequest(res);
        }
        return Ok(res);
    }
    [HttpDelete("Employee")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteEmployeeDto softDeleteEmployeeDto)
    {
        var res = await mediator.Send(new SoftDeleteEmployeeRequest() { RowId = softDeleteEmployeeDto .RowId});
        if (!res.IsSuccess)
        {
            return BadRequest(res);
        }
        return Ok(res);
    }

    /// new API With better arc base on REAL DDD ARCH
    /// 
    [HttpPost("Hire")]
    public async Task<IActionResult> HireEmploee([FromBody] HireEmployeeDto hireEmployeeDto)
    {
        var res = await mediator.Send(new HireEmployeeRequest() { HireEmpoyeeDto = hireEmployeeDto });
        if (!res.IsSuccess)
        {
            return BadRequest(res);
        }
        return Ok(res);
    }
        


}
