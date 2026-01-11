using MyApp.Core.DTOs.Center;
using MyApp.Core.Entities.CenterMasterEntites;
using MyApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _repository;

        public CenterService(ICenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateCenterDto dto)
        {
            var center = new Center
            {
                CenterName = dto.CenterName.Trim(),
                ContactPerson = dto.ContactPerson,
                Contactnumber = dto.Contactnumber,
                CenterCode = dto.CenterCode.Trim(),
                Address = dto.Address,
                IsActive = true
            };

            return await _repository.CreateAsync(center);
        }

        public async Task UpdateAsync(int id, UpdateCenterDto dto)
        {
            var center = await _repository.GetByIdAsync(id)
                ?? throw new ApplicationException("Center not found");

            center.CenterName = dto.CenterName.Trim();
            center.ContactPerson = dto.ContactPerson;
            center.Contactnumber = dto.Contactnumber;
            center.CenterCode = dto.CenterCode.Trim();
            center.Address = dto.Address;
            center.IsActive = dto.IsActive;

            await _repository.UpdateAsync(center);
        }

        public async Task DeleteAsync(int id)
        {
            var center = await _repository.GetByIdAsync(id)
                ?? throw new ApplicationException("Center not found");

            center.IsActive = false;
            await _repository.UpdateAsync(center);
        }

        public async Task<Center?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Center>> GetAllAsync()
            => await _repository.GetAllAsync();
    }

}
