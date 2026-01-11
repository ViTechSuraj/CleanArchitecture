using MyApp.Core.DTOs.Roles;
using MyApp.Core.Entities.RoleMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IRoleService
    {
        Task<int> CreateAsync(CreateRoleDto dto);
        Task UpdateAsync(int id, UpdateRoleDto dto);
        Task<Roles?> GetByIdAsync(int id); 
        Task<List<Roles>> GetAllAsync();
    }

}
