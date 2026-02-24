using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Interfaces
{
    public interface IEmployerRepository:IGenericRepository<Employer>
    {
        Task<Employer?> GetByUserIdAsync(int userId);
    }
}
