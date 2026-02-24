using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetWithRefreshTokensAsync(int userId);

    }
}
