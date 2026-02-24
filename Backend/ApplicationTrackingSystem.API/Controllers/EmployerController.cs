using ApplicationTrackingSystem.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApplicationTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _service;
        public EmployerController(IEmployerService service) => _service = service;

        private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost("profile")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> CreateProfile([FromBody] CreateEmployerProfileDto dto)
            => Ok(await _service.CreateProfileAsync(UserId, dto));

        [HttpPut("profile")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateEmployerProfileDto dto)
            => Ok(await _service.UpdateProfileAsync(UserId, dto));

        [HttpGet("profile")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetProfile()
            => Ok(await _service.GetProfileByUserIdAsync(UserId));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _service.GetProfileByIdAsync(id));

        [HttpPost("logo")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UploadLogo([FromForm] IFormFile file)
            => Ok(new { url = await _service.UploadLogoAsync(UserId, file) });

        [HttpGet("dashboard")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Dashboard()
            => Ok(await _service.GetDashboardAsync(UserId));

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            await _service.ApproveEmployerAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            await _service.RejectEmployerAsync(id);
            return NoContent();
        }
    }
}
