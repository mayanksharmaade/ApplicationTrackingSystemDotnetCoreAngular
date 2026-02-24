using ApplicationTrackingSystem.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApplicationTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        
            private readonly ICandidateService _service;
            public CandidateController(ICandidateService service) => _service = service;

            private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            [HttpPost("profile")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> CreateProfile([FromBody] CreateCandidateProfileDto dto)
                => Ok(await _service.CreateProfileAsync(UserId, dto));

            [HttpPut("profile")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> UpdateProfile([FromBody] UpdateCandidateProfileDto dto)
                => Ok(await _service.UpdateProfileAsync(UserId, dto));

            [HttpGet("profile")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> GetProfile()
                => Ok(await _service.GetProfileByUserIdAsync(UserId));

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
                => Ok(await _service.GetProfileByIdAsync(id));

            [HttpPost("skills")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> AddSkill([FromBody] AddSkillDto dto)
            {
                await _service.AddSkillAsync(UserId, dto);
                return NoContent();
            }

            [HttpDelete("skills/{skillId}")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> RemoveSkill(int skillId)
            {
                await _service.RemoveSkillAsync(UserId, skillId);
                return NoContent();
            }

            [HttpPost("experiences")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> AddExperience([FromBody] ExperienceDto dto)
                => Ok(await _service.AddExperienceAsync(UserId, dto));

            [HttpPut("experiences/{id}")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> UpdateExperience(int id, [FromBody] ExperienceDto dto)
            {
                await _service.UpdateExperienceAsync(UserId, id, dto);
                return NoContent();
            }

            [HttpDelete("experiences/{id}")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> DeleteExperience(int id)
            {
                await _service.DeleteExperienceAsync(UserId, id);
                return NoContent();
            }

            [HttpPost("educations")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> AddEducation([FromBody] EducationDto dto)
                => Ok(await _service.AddEducationAsync(UserId, dto));

            [HttpPut("educations/{id}")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> UpdateEducation(int id, [FromBody] EducationDto dto)
            {
                await _service.UpdateEducationAsync(UserId, id, dto);
                return NoContent();
            }

            [HttpDelete("educations/{id}")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> DeleteEducation(int id)
            {
                await _service.DeleteEducationAsync(UserId, id);
                return NoContent();
            }

         

           

            [HttpGet("dashboard")]
            [Authorize(Roles = "Candidate")]
            public async Task<IActionResult> Dashboard()
                => Ok(await _service.GetDashboardAsync(UserId));
        }

    }

