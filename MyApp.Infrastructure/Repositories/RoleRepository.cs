using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities.RoleMasterEntites;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Roles role)
        {
            _context.RoleMaster.Add(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public async Task UpdateAsync(Roles role)
        {
            _context.RoleMaster.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Roles?> GetByIdAsync(int id)
        {
            return await _context.RoleMaster
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Roles>> GetAllAsync()
        {
            return await _context.RoleMaster
                .AsNoTracking()
                .OrderBy(x => x.RoleName)
                .ToListAsync();
        }
    }

}
