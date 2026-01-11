using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Repositories;
using MyApp.Core.Entities.EmployeeMasterEntites;
using MyApp.Core.Interface;
using MyApp.Infrastructure.Interface;
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
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {


            services.AddScoped<ICornerArticleInterface, CornerArticleInterface>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICenterService, CenterService>();
            return services; 
        }
    }
}
