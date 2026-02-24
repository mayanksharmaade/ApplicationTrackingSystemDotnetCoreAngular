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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
       public UserRepository(ApplicationDbContext ctx) : base(ctx) 
        {
            
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
           var user=  await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public  async Task<User?> GetWithRefreshTokensAsync(int userId)
        {
             var user= await _ctx.Users.Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Id == userId);

            return user;

        }
    }
}
