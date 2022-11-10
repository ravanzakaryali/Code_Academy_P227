namespace p227FirstApi.DTOs.StudentDtos;

public class StudentCreateDto
{
    public string Name { get; set; } = null!;
    public string? Surname { get; set; }
    public int Age { get; set; }
}

