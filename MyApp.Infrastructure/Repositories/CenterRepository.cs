using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities.CenterMasterEntites;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly ApplicationDbContext _context;

        public CenterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Center center)
        {
            try
            {
                _context.CenterMaster.Add(center);
                await _context.SaveChangesAsync();
                return center.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating center", ex);
            }
        }

        public async Task UpdateAsync(Center center)
        {
            try
            {
                _context.CenterMaster.Update(center);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating center", ex);
            }
        }

        public async Task<Center?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.CenterMaster
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching center by id", ex);
            }
        }

        public async Task<List<Center>> GetAllAsync()
        {
            try
            {
                return await _context.CenterMaster
                    .AsNoTracking()
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CenterName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching center list", ex);
            }
        }
    }


}
