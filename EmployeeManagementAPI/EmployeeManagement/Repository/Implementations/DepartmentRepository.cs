using EmployeeManagement.DataAccess;
using EmployeeManagement.Entities;
using EmployeeManagement.Repository.Implementations.Base;
using EmployeeManagement.Repository.Interfaces;

namespace EmployeeManagement.Repository.Implementations;

public class DepartmentRepository : Repository<Department,string>,IDepartmentRepository
{
	public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
	{

	}

}
