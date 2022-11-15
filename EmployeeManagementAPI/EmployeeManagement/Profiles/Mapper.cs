
using AutoMapper;
using EmployeeManagement.DTOs.DepartmentDtos;
using EmployeeManagement.DTOs.EmployeeDtos;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Profiles;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<Department, DepartmentGetDto>();
        CreateMap<EmployeeCreateDto, Employee>();
    }
}
