using EmployeeManagement.DataAccess;
using EmployeeManagement.Entities;
using EmployeeManagement.Repository.Implementations.Base;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.Implementations;

public class EmployeeRepository : Repository<Employee, string>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}
