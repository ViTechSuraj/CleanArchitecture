using MyApp.Application.Interfaces;
using MyApp.Core.DTOs.Roles;
using MyApp.Core.Entities.RoleMasterEntites;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Repositories
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateRoleDto dto)
        {
            var role = new Roles
            {
                RoleName = dto.RoleName.Trim(),
                IsActive = true
            };

            return await _repository.CreateAsync(role);
        }

        public async Task UpdateAsync(int id, UpdateRoleDto dto)
        {
            var role = await _repository.GetByIdAsync(id)
                ?? throw new ApplicationException("Role not found");

            role.RoleName = dto.RoleName.Trim();
            role.IsActive = dto.IsActive;

            await _repository.UpdateAsync(role);
        }

        public async Task<Roles?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Roles>> GetAllAsync()
            => await _repository.GetAllAsync();
    }

}
