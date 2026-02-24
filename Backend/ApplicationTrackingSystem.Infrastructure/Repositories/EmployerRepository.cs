using ApplicationTrackingSystem.Infrastructure.Data;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using ApplicationTrackingSytem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Infrastructure.Repositories
{
    public class EmployerRepository: GenericRepository<Employer>,IEmployerRepository
    {
        public EmployerRepository(ApplicationDbContext ctx): base(ctx) { }
       

        public async Task<Employer?> GetByUserIdAsync(int userId)
        {
            var user = await _ctx.Employers.Include(e => e.User).Include(e => e.Jobs)
            .FirstOrDefaultAsync(e => e.UserId == userId);

            return user;
        }

    }
}

