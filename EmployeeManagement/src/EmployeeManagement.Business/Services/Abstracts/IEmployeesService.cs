using EmployeeManagement.Business.DTOs.EmployeeDtos;

namespace EmployeeManagement.Business.Services.Abstracts;

public interface IEmployeesService
{
    Task<EmployeeGetDto> GetAsync(string id);
}
