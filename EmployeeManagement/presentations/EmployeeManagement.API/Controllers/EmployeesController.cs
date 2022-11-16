using EmployeeManagement.API.Controllers.Base;
using EmployeeManagement.Business.Common;
using EmployeeManagement.Business.Exceptions.NotFoundExceptions;
using EmployeeManagement.Business.Services.Abstracts;
using EmployeeManagement.Business.Services.Concrets;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.API.Controllers;



public class EmployeesController : BaseApiController
{
    private readonly IEmployeesService _service;
    public EmployeesController(IEmployeesService service)
    {
        _service = service;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        try
        {
            return Ok(new Response
            {
                Data = await _service.GetAsync(id),
                StatusCodes = HttpStatusCode.OK,
                Message = "Success"
            });
        }
        catch(NotFoundException ex)
        {
            return NotFound(new Response
            {
                Data = null,
                StatusCodes = HttpStatusCode.NotFound,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,new Response
            {
                Data = null,
                Message = ex.Message,
                StatusCodes = HttpStatusCode.InternalServerError,
            });
        }
    }

    

}
