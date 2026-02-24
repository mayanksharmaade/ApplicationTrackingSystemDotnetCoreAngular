using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class Employer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; } = default!;
        public string? Industry { get; set; }
        public string? CompanySize { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsApprovedByAdmin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = default!;
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
