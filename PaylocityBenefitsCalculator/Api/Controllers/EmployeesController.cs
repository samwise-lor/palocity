using Api.Dtos;
using Api.Dtos.Employee;
using Api.Models;
using Api.Query;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : BaseApiController
{
    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        return HandleResult(await Mediator.Send(new EmloyeeQueryById.Query { Id = id }));
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {        
        return HandleResult(await Mediator.Send(new EmployeeQuery.Query()));        
    }

    [SwaggerOperation(Summary = "Get employee paycheck")]
    [HttpGet("paycheck/{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeSalaryDto>>> GetEmployeePaycheck(int id)
    {
        return HandleResult(await Mediator.Send(new EmloyeeSalaryQueryById.Query { Id = id }));
    }
}
