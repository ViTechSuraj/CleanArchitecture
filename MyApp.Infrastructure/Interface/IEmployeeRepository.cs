using MyApp.Core.Entities.EmployeeMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Interface
{
    public interface IEmployeeRepository
    {
        Task<int> CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> GetByLoginAsync(string login);
        Task<List<Employee>> GetAllAsync();
    }


}
