using ApplicationTrackingSytem.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class JobSkill
    {
        public int JobId { get; set; }
        public int SkillId { get; set; }
        public bool IsRequired { get; set; } = true;
        public Job Job { get; set; } = default!;
        public Skill Skill { get; set; } = default!;
    }
}
