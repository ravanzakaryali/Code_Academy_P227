using AutoMapper;
using EmployeeManagement.Entities;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeparmentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            Department? departmentDb = await _unitOfWork.DepartmentRepository.GetAsync(id);
            if (departmentDb is null) return NotFound();
            return Ok(departmentDb);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string name)
        {
            return Ok(await _unitOfWork.DepartmentRepository.GetAllAsync(d => d.Name.Contains(name)));
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
