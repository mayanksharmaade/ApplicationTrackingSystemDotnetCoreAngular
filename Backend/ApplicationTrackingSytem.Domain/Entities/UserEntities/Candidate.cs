using ApplicationTrackingSytem.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class Candidate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhotoUrl { get; set; }
        public string? CVUrl { get; set; }
        public string? CoverLetterUrl { get; set; }
        public string? Summary { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = default!;
        public ICollection<CandidateSkill> Skills { get; set; } = new List<CandidateSkill>();
        public ICollection<CandidateExperience> Experiences { get; set; } = new List<CandidateExperience>();
        public ICollection<CandidateEducation> Educations { get; set; } = new List<CandidateEducation>();
       // public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
