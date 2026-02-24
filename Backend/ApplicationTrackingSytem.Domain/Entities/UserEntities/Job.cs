using ApplicationTrackingSytem.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ApplicationTrackingSystem.Domain.Enums;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class Job
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Requirements { get; set; }
        public string? Benefits { get; set; }
        public JobType JobType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; } = ExperienceLevel.Mid;
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string Currency { get; set; } = "USD";
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsRemote { get; set; }
        public JobStatus Status { get; set; } = JobStatus.Draft;
        public bool IsApprovedByAdmin { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime? PostedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Employer Employer { get; set; } = default!;
        public JobCategory? Category { get; set; }
        public ICollection<JobSkill> Skills { get; set; } = new List<JobSkill>();
       // public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
