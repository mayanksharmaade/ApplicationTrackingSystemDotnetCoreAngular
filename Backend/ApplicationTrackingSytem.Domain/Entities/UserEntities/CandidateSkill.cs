using ApplicationTrackingSystem.Domain.Enums;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.User
{
    public class CandidateSkill
    {
        public int CandidateId { get; set; }
        public int SkillId { get; set; }
        public ProficiencyLevel Proficiency { get; set; } = ProficiencyLevel.Intermediate;
        public Candidate Candidate { get; set; } = default!;
        public Skill Skill { get; set; } = default!;
    }
}

