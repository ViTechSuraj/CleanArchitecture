using MyApp.Core.Entities.RoleMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Interface
{
    public interface IRoleRepository
    {
        Task<int> CreateAsync(Roles role);
        Task UpdateAsync(Roles role);
        Task<Roles?> GetByIdAsync(int id);
        Task<List<Roles>> GetAllAsync();
    }

}
