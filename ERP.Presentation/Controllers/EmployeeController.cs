using Asp.Versioning;
using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Commands.Employee.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Presentation.Controllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator mediator;

    public EmployeeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Employee")]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployee)
    {
        var res = await mediator.Send(new CreateEmployeeRequest() { CreateEmployeeDto = createEmployee });
        if (!res.IsSuccess)
        {
            return BadRequest(res);
        }
        return Ok(res);
    }
}
