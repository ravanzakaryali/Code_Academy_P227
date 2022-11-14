
using AutoMapper;
using EmployeeManagement.DTOs;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Profiles;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<Department, DepartmentGetDto>();
    }
}
