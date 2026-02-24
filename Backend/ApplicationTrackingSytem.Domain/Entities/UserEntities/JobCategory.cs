using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.User
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
