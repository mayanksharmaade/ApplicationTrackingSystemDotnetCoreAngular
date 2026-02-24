using ApplicationTrackingSystem.Business.Interfaces;
using ApplicationTrackingSystem.Domain.Enums;
using ApplicationTrackingSytem.Domain.Entities.User;
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
    public class CandidateService:ICandidateService
    {
        private readonly IUnitofWork _uow;
        private readonly IFileStorageService _files;

        public CandidateService(IUnitofWork uow,IFileStorageService files)
        {
            _uow = uow;
            _files = files;
        }

        public async Task<CandidateProfileDto> CreateProfileAsync(int userId, CreateCandidateProfileDto dto)
        {
            var candidate = new Candidate
            {
                UserId = userId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                Summary = dto.Summary,
                LinkedInUrl = dto.LinkedInUrl,
                GitHubUrl = dto.GitHubUrl,
            };
            await _uow.Candidates.AddAsync(candidate);
            await _uow.SaveChangesAsync();
            return MapProfile(candidate);
        }

        public async Task<CandidateProfileDto> UpdateProfileAsync(int userId, UpdateCandidateProfileDto dto)
        {
            var c = new Candidate();
            try
            {
                 c = await _uow.Candidates.GetByUserIdAsync(userId)
                    ?? throw new InvalidOperationException("Profile not found.");
                if (c.UserId == userId)
                {
                    c.FirstName = dto.FirstName;
                    c.LastName = dto.LastName;
                    c.PhoneNumber = dto.PhoneNumber;
                    c.DateOfBirth = dto.DateOfBirth;
                    c.City = dto.City;
                    c.Country = dto.Country;
                    c.Summary = dto.Summary;
                    c.LinkedInUrl = dto.LinkedInUrl;
                    c.GitHubUrl = dto.GitHubUrl;
                    c.UpdatedAt = DateTime.UtcNow;
                }
                await _uow.Candidates.UpdateAsync(c);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return MapProfile(c);
        }

        public async Task<CandidateProfileDto?> GetProfileByUserIdAsync(int userId)
        {
            var c = await _uow.Candidates.GetCandidateWithDetailsAsync(
                (await _uow.Candidates.GetByUserIdAsync(userId))?.Id ?? 0);
            return c == null ? null : MapProfile(c);
        }

        public async Task<CandidateProfileDto?> GetProfileByIdAsync(int id)
        {
            var c = await _uow.Candidates.GetCandidateWithDetailsAsync(id);
            return c == null ? null : MapProfile(c);
        }

        public async Task AddSkillAsync(int userId, AddSkillDto dto)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            // Check not duplicate
            var ctx = (c as dynamic); // Use UoW context directly
                                      // Add via context
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveSkillAsync(int userId, int skillId)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            await _uow.SaveChangesAsync();
        }

        public async Task<ExperienceDto> AddExperienceAsync(int userId, ExperienceDto dto)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var exp = new CandidateExperience
            {
                CandidateId = c.Id,
                JobTitle = dto.JobTitle,
                CompanyName = dto.CompanyName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsCurrent = dto.IsCurrent,
                Description = dto.Description,
            };
            await _uow.SaveChangesAsync();
            return MapExp(exp);
        }

        public async Task UpdateExperienceAsync(int userId, int expId, ExperienceDto dto)
        {
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteExperienceAsync(int userId, int expId)
        {
            await _uow.SaveChangesAsync();
        }

        public async Task<EducationDto> AddEducationAsync(int userId, EducationDto dto)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var edu = new CandidateEducation
            {
                CandidateId = c.Id,
                Institution = dto.Institution,
                Degree = dto.Degree,
                FieldOfStudy = dto.FieldOfStudy,
                StartYear = dto.StartYear,
                EndYear = dto.EndYear,
                Grade = dto.Grade,
            };
            await _uow.SaveChangesAsync();
            return dto with { Id = edu.Id };
        }

        public async Task UpdateEducationAsync(int userId, int eduId, EducationDto dto) =>
            await _uow.SaveChangesAsync();

        public async Task DeleteEducationAsync(int userId, int eduId) =>
            await _uow.SaveChangesAsync();

        public async Task<string?> UploadPhotoAsync(int userId, IFormFile file)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var url = await _files.UploadAsync(file, "photos");
            c.PhotoUrl = url;
            await _uow.Candidates.UpdateAsync(c);
            await _uow.SaveChangesAsync();
            return url;
        }

        public async Task<string?> UploadCVAsync(int userId, IFormFile file)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var url = await _files.UploadAsync(file, "cvs");
            c.CVUrl = url;
            await _uow.Candidates.UpdateAsync(c);
            await _uow.SaveChangesAsync();
            return url;
        }

        public async Task<string?> UploadCoverLetterAsync(int userId, IFormFile file)
        {
            var c = await _uow.Candidates.GetByUserIdAsync(userId)
                ?? throw new InvalidOperationException("Profile not found.");
            var url = await _files.UploadAsync(file, "coverletters");
            c.CoverLetterUrl = url;
            await _uow.Candidates.UpdateAsync(c);
            await _uow.SaveChangesAsync();
            return url;
        }

        

        private static CandidateProfileDto MapProfile(Candidate c) => new(
            c.Id, c.UserId, c.FirstName, c.LastName, c.PhoneNumber, c.DateOfBirth,
            c.City, c.Country, c.PhotoUrl, c.CVUrl, c.CoverLetterUrl, c.Summary,
            c.LinkedInUrl, c.GitHubUrl,
            c.Skills.Select(s => new CandidateSkillDto(s.SkillId, s.Skill?.Name ?? "", s.Proficiency.ToString())).ToList(),
            c.Experiences.Select(MapExp).ToList(),
            c.Educations.Select(e => new EducationDto(e.Id, e.Institution, e.Degree, e.FieldOfStudy, e.StartYear, e.EndYear, e.Grade)).ToList());

        private static ExperienceDto MapExp(CandidateExperience e) => new(
            e.Id, e.JobTitle, e.CompanyName, e.StartDate, e.EndDate, e.IsCurrent, e.Description);

        public Task<CandidateDashboardDto> GetDashboardAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }


}

