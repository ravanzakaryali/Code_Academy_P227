using EmployeeManagement.Repository.Interfaces;

namespace EmployeeManagement.UnitOfWork.Interface;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get;}
    Task<int> SaveChangesAsync();
}
