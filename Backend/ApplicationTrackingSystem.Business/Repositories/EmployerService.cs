using ApplicationTrackingSystem.Business.Interfaces;
using ApplicationTrackingSystem.Domain.Enums;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using ApplicationTrackingSytem.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Repositories
{
    internal class EmployerService:IEmployerRepository
    {
        private readonly IUnitofWork _uow;
        private readonly IFileStorageService _files;

        public EmployerService(IUnitofWork uow, IFileStorageService files)
        {
            _uow = uow;
            _files = files;
        }

        public async Task<EmployerDto> CreateProfileAsync(int userId, CreateEmployerProfileDto dto)
        {
            var employer = new Employer
            {
                UserId = userId,
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                CompanySize = dto.CompanySize,
                Website = dto.Website,
                Description = dto.Description,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
            };
            await _uow.Employers.AddAsync(employer);
            await _uow.SaveChangesAsync();
            return Map(employer);
        }

        public async Task<EmployerDto> UpdateProfileAsync(int userId, UpdateEmployerProfileDto dto)
        {
            var e = await _uow.Employers.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            e.CompanyName = dto.CompanyName; e.Industry = dto.Industry;
            e.CompanySize = dto.CompanySize; e.Website = dto.Website;
            e.Description = dto.Description; e.City = dto.City; e.Country = dto.Country;
            await _uow.Employers.UpdateAsync(e);
            await _uow.SaveChangesAsync();
            return Map(e);
        }

        public async Task<EmployerDto?> GetProfileByUserIdAsync(int userId)
        {
            var e = await _uow.Employers.GetByUserIdAsync(userId);
            return e == null ? null : Map(e);
        }

        public async Task<EmployerDto?> GetProfileByIdAsync(int id)
        {
            var e = await _uow.Employers.GetByIdAsync(id);
            return e == null ? null : Map(e);
        }

        public async Task<string?> UploadLogoAsync(int userId, IFormFile file)
        {
            var e = await _uow.Employers.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var url = await _files.UploadAsync(file, "logos");
            e.LogoUrl = url;
            await _uow.Employers.UpdateAsync(e);
            await _uow.SaveChangesAsync();
            return url;
        }

       

        public async Task<IEnumerable<EmployerDto>> GetAllAsync()
        {
            var all = await _uow.Employers.GetAllAsync();
            return all.Select(Map);
        }

        public async Task ApproveEmployerAsync(int id)
        {
            var e = await _uow.Employers.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            e.IsApprovedByAdmin = true;
            await _uow.Employers.UpdateAsync(e);
            await _uow.SaveChangesAsync();
        }

        public async Task RejectEmployerAsync(int id)
        {
            var e = await _uow.Employers.GetByIdAsync(id) ?? throw new KeyNotFoundException();
            e.IsApprovedByAdmin = false;
            await _uow.Employers.UpdateAsync(e);
            await _uow.SaveChangesAsync();
        }

        private static EmployerDto Map(Employer e) => new(
            e.Id, e.UserId, e.CompanyName, e.Industry, e.CompanySize, e.Website,
            e.Description, e.LogoUrl, e.City, e.Country, e.IsApprovedByAdmin, e.CreatedAt);

        public Task<Employer?> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Employer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Employer>> IGenericRepository<Employer>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employer> AddAsync(Employer entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Employer entity)
        {
            throw new NotImplementedException();
        }
    }
}
