using EmployeeManagement.Business.Concrets.UnitOfWork;
using EmployeeManagement.Business.Services.Abstracts;
using EmployeeManagement.Business.Services.Concrets;
using EmployeeManagement.DataAccess.Abstracs.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeManagement.Business;

public static class ConfigureServices
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeesService, EmployeesService>();
        return services;
    }
}
