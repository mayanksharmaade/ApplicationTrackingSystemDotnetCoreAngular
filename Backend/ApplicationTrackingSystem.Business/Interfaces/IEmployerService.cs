using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Interfaces
{
    public interface IEmployerService
    {
        Task<EmployerDto> CreateProfileAsync(int userId, CreateEmployerProfileDto dto);
        Task<EmployerDto> UpdateProfileAsync(int userId, UpdateEmployerProfileDto dto);
        Task<EmployerDto?> GetProfileByUserIdAsync(int userId);
        Task<EmployerDto?> GetProfileByIdAsync(int employerId);
        Task<string?> UploadLogoAsync(int userId, IFormFile file);
        Task<EmployerDashboardDto> GetDashboardAsync(int userId);
        Task<IEnumerable<EmployerDto>> GetAllAsync();
        Task ApproveEmployerAsync(int employerId);
        Task RejectEmployerAsync(int employerId);
    }
}
