using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Commands.Employee.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Presentation.Controllers;

public class EmployeeController : Controller
{
    private readonly IMediator mediator;

    public EmployeeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("A")]
    public async Task< IActionResult> Index(CreateEmployeeDto createEmployee)
    {
        var es = await mediator.Send(new CreateEmployeeRequest() { CreateEmployeeDto = createEmployee });
        return View(es);
    }
}
