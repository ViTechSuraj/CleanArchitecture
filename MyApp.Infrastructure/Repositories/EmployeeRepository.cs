using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities.EmployeeMasterEntites;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Employee employee)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "CALL sp_employee_insert({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                    employee.FirstName,
                    employee.LastName,
                    employee.Gender,
                    employee.PhoneNumber,
                    employee.Email,
                    employee.RoleId,
                    employee.CenterId,
                    employee.Login,
                    employee.Password
                );

                var createdEmployee = await GetByLoginAsync(employee.Login);

                if (createdEmployee == null)
                {
                    throw new InvalidOperationException(
                        "Employee created but unable to retrieve the record."
                    );
                }

                return createdEmployee.Id;
            }
            catch (DbUpdateException ex)
            {
                // 🔐 MySQL duplicate key (login)
                if (ex.InnerException?.Message.Contains("Duplicate") == true)
                {
                    throw new ApplicationException(
                        "Employee with the same login already exists."
                    );
                }

                throw;
            }
            catch (Exception)
            {
                // Let global middleware handle it
                throw;
            }
        }


        public async Task UpdateAsync(Employee employee)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "CALL sp_employee_update({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.Gender,
                employee.PhoneNumber,
                employee.Email,
                employee.RoleId,
                employee.CenterId,
                employee.IsActive
            );
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var result = await _context.Employees
                .FromSqlRaw("CALL sp_employee_get_by_id({0})", id)
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<Employee?> GetByLoginAsync(string login)
        {
            var result = await _context.Employees
                .FromSqlRaw("CALL sp_employee_login({0})", login)
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .FromSqlRaw("CALL sp_employee_get_all()")
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
