using MyApp.Core.DTOs.Center;
using MyApp.Core.Entities.CenterMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Interface
{
    public interface ICenterService
    {
        Task<int> CreateAsync(CreateCenterDto dto);
        Task UpdateAsync(int id, UpdateCenterDto dto);
        Task DeleteAsync(int id);
        Task<Center?> GetByIdAsync(int id);
        Task<List<Center>> GetAllAsync();
    }

}
