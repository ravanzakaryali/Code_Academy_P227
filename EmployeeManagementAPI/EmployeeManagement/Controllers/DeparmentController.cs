using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DTOs;
using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeparmentController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> departmentsDb = await _dbContext.Departments.ToListAsync();
            List<DepartmentGetDto> departments = _mapper.Map<List<DepartmentGetDto>>(departmentsDb);
            return Ok(departments);
        }
        
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync(string id)
        //{
        //    Employee? employee = _dbContext.Employees.Find(id);
        //    if (employee == null) return NotFound();
            
        //    employee.Name = "D 6";

        //    //_dbContext.Departments.Update(new Department
        //    //{
        //    //    Name = "D 2"
        //    //});
        //    await _dbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
