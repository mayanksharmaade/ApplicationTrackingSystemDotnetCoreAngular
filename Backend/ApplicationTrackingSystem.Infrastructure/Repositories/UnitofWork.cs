using ApplicationTrackingSystem.Infrastructure.Data;
using ApplicationTrackingSytem.Domain.Entities.User;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using ApplicationTrackingSytem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Infrastructure.Repositories
{
    public class UnitofWork : IUnitofWork
    {

        private readonly ApplicationDbContext _ctx;
        public IUserRepository Users { get; }
        public IEmployerRepository Employers { get; }
        public ICandidateRepository Candidates { get; }

        public UnitofWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Users = new UserRepository(_ctx);
            Employers = new EmployerRepository(_ctx);
            Candidates = new CandidateRepository(_ctx);
        }
        

      

        public IGenericRepository<Skill> Skills => throw new NotImplementedException();

        public IGenericRepository<JobCategory> JobCategories => throw new NotImplementedException();

        public IGenericRepository<Notification> Notifications => throw new NotImplementedException();

        public IGenericRepository<EmailLog> EmailLogs => throw new NotImplementedException();

        public async Task<int> SaveChangesAsync() => await _ctx.SaveChangesAsync();
        public void Dispose() => _ctx.Dispose();
    }
}
