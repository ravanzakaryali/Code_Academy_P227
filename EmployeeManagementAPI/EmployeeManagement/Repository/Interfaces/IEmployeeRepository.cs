using EmployeeManagement.Entities;
using EmployeeManagement.Repository.Interfaces.Base;

namespace EmployeeManagement.Repository.Interfaces;

public interface IEmployeeRepository : IRepository<Employee,string>
{
    
}
