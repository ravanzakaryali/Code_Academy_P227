using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using p227FirstApi.DataAccess;
using p227FirstApi.DTOs.StudentDtos;
using p227FirstApi.Entities;

namespace p227FirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public StudentsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _dbContext.Students.ToListAsync());
        //return StatusCode(200, _students.ToList());
        //return StatusCode(StatusCodes.Status200OK, _students.ToList());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        Student? student = await _dbContext.Students.FindAsync(id);
        if (student is null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] StudentCreateDto student)
    {
        _dbContext.Students.Add(new Student
        {
            Age = student.Age,
            Name = student.Name,
            Surname = student.Surname
        });
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentUpdateDto updateDto)
    {
        Student? studentDb =  await _dbContext.Students.FindAsync(id);
        if (studentDb is null) return NotFound();
        studentDb.Age = updateDto.Age == 0 ? studentDb.Age : updateDto.Age;
        studentDb.Surname = updateDto.Surname;
        studentDb.Name = updateDto.Name is null ? studentDb.Name : updateDto.Name;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        Student? studentDb = await _dbContext.Students.FindAsync(id);
        if (studentDb is null) return NotFound();
        _dbContext.Students.Remove(studentDb);
        await _dbContext.SaveChangesAsync();
        return Ok(new
        {
            Message = "Student delete",
            StatusCode = StatusCodes.Status200OK,
            studentDb.Id
        });
    }

}
