using ApplicationTrackingSytem.Domain.Entities.User;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Interfaces
{
    public interface IUnitofWork:IDisposable
    {
        IUserRepository Users { get; }
        IEmployerRepository Employers { get; }
       ICandidateRepository Candidates { get; }
      //  IJobRepository Jobs { get; }
       // IApplicationRepository Applications { get; }
        IGenericRepository<Skill> Skills { get; }
        IGenericRepository<JobCategory> JobCategories { get; }
        IGenericRepository<Notification> Notifications { get; }
        IGenericRepository<EmailLog> EmailLogs { get; }

        Task<int> SaveChangesAsync();
    }
}
