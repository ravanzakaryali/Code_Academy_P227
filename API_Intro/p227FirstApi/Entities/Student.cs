using System.ComponentModel.DataAnnotations;

namespace p227FirstApi.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Surname { get; set; } 
    public int Age { get; set; }
}
