using MyApp.Core.Entities.CenterMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Interface
{
    public interface ICenterRepository
    {
        Task<int> CreateAsync(Center center);
        Task UpdateAsync(Center center);
        Task<Center?> GetByIdAsync(int id);
        Task<List<Center>> GetAllAsync();
    }

}
