using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.User
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();
        public ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
    }
}

