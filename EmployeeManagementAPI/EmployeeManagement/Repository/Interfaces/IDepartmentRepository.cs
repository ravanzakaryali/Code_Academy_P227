using EmployeeManagement.Entities;
using EmployeeManagement.Repository.Interfaces.Base;

namespace EmployeeManagement.Repository.Interfaces;

public interface IDepartmentRepository : IRepository<Department,string>
{
}
