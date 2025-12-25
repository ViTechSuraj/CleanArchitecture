using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Repositories;
using MyApp.Core.Entities.EmployeeMasterEntites;
using MyApp.Core.Interface;
using MyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection service)
        {


            service.AddScoped<ICornerArticleInterface, CornerArticleInterface>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
            return service; 
        }
    }
}
