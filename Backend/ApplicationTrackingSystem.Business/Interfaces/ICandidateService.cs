using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Interfaces
{
    public interface ICandidateService
    {
        Task<CandidateProfileDto> CreateProfileAsync(int userId, CreateCandidateProfileDto dto);
        Task<CandidateProfileDto> UpdateProfileAsync(int userId, UpdateCandidateProfileDto dto);
        Task<CandidateProfileDto?> GetProfileByUserIdAsync(int userId);
        Task<CandidateProfileDto?> GetProfileByIdAsync(int candidateId);
        Task AddSkillAsync(int userId, AddSkillDto dto);
        Task RemoveSkillAsync(int userId, int skillId);
        Task<ExperienceDto> AddExperienceAsync(int userId, ExperienceDto dto);
        Task UpdateExperienceAsync(int userId, int experienceId, ExperienceDto dto);
        Task DeleteExperienceAsync(int userId, int experienceId);
        Task<EducationDto> AddEducationAsync(int userId, EducationDto dto);
        Task UpdateEducationAsync(int userId, int educationId, EducationDto dto);
        Task DeleteEducationAsync(int userId, int educationId);
        Task<string?> UploadPhotoAsync(int userId, IFormFile file);
        Task<string?> UploadCVAsync(int userId, IFormFile file);
        Task<string?> UploadCoverLetterAsync(int userId, IFormFile file);
        Task<CandidateDashboardDto> GetDashboardAsync(int userId);
    }
}
