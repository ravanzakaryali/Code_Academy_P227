using AutoMapper;
using EmployeeManagement.Business.Common;
using EmployeeManagement.Business.DTOs.EmployeeDtos;
using EmployeeManagement.Business.Exceptions.NotFoundExceptions;
using EmployeeManagement.Business.Services.Abstracts;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.DataAccess.Abstracs.UnitOfWork;

namespace EmployeeManagement.Business.Services.Concrets;

public class EmployeesService : IEmployeesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmployeesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<EmployeeGetDto> GetAsync(string id)
    {
        Employee? employee = await _unitOfWork.EmployeeRepository.GetAsync(id);
        if (employee is null) throw new EntityNotFoundException("Employee not found");
        return _mapper.Map<EmployeeGetDto>(employee);
    }
}
