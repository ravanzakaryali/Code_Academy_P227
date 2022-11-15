using AutoMapper;
using EmployeeManagement.DTOs.EmployeeDtos;
using EmployeeManagement.Entities;
using EmployeeManagement.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		return Ok(await _unitOfWork.EmployeeRepository.GetAllAsync(null, nameof(Department)));
	}
	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreateDto employeeDto)
	{
		if (await _unitOfWork.DepartmentRepository.GetAsync(employeeDto.DepartmentId) is null) return NotFound();
		await _unitOfWork.EmployeeRepository.AddAsync(_mapper.Map<Employee>(employeeDto));
		return NoContent();
	}
}
