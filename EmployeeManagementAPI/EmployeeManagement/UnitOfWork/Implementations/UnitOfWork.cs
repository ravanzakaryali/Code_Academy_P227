using EmployeeManagement.DataAccess;
using EmployeeManagement.Repository.Implementations;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.UnitOfWork.Interface;

namespace EmployeeManagement.UnitOfWork.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private IEmployeeRepository? _employeeRepository;
    private IDepartmentRepository? _departmentRepository;
    public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_dbContext);
    public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_dbContext);

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
