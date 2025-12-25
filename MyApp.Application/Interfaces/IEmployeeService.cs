using MyApp.Core.DTOs.EmployeeMasterDtos;
using MyApp.Core.DTOs.LoginDtos;
using MyApp.Core.Entities.EmployeeMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task UpdateAsync(int id, UpdateEmployeeDto dto);
        Task<Employee?> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> LoginAsync(LoginDto dto);
    }
}
