using Microsoft.AspNetCore.Identity;
using MyApp.Application.Interfaces;
using MyApp.Core.DTOs.EmployeeMasterDtos;
using MyApp.Core.DTOs.LoginDtos;
using MyApp.Core.Entities.EmployeeMasterEntites;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public EmployeeService(
            IEmployeeRepository repository,
            IPasswordHasher<Employee> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        // 🔹 CREATE EMPLOYEE
        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            // 🔐 Validation
            if (string.IsNullOrWhiteSpace(dto.Login))
                throw new ApplicationException("Login is required");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ApplicationException("Password is required");

            // 🧠 Entity Mapping
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                RoleId = dto.RoleId,
                CenterId = dto.CenterId,
                Login = dto.Login,
                IsActive = true
            };

            // 🔐 Password Hashing
            employee.Password = _passwordHasher.HashPassword(employee, dto.Password);

            return await _repository.CreateAsync(employee);
        }

        // 🔹 UPDATE EMPLOYEE
        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(id)
                ?? throw new ApplicationException("Employee not found");

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Gender = dto.Gender;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Email = dto.Email;
            employee.RoleId = dto.RoleId;
            employee.CenterId = dto.CenterId;
            employee.IsActive = dto.IsActive;

            await _repository.UpdateAsync(employee);
        }

        // 🔹 GET BY ID
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // 🔹 GET ALL
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // 🔹 LOGIN (Used by Login Screen)
        public async Task<Employee> LoginAsync(LoginDto dto)
        {
            var employee = await _repository.GetByLoginAsync(dto.Login)
                ?? throw new ApplicationException("Invalid login credentials");

            var result = _passwordHasher.VerifyHashedPassword(
                employee,
                employee.Password,
                dto.Password
            );

            if (result == PasswordVerificationResult.Failed)
                throw new ApplicationException("Invalid login credentials");

            if (!employee.IsActive)
                throw new ApplicationException("User is inactive");

            return employee;
        }
    }
}
