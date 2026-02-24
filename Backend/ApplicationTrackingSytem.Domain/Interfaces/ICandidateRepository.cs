using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Interfaces
{
    public interface ICandidateRepository:IGenericRepository<Candidate>
    {
        Task<Candidate?> GetByUserIdAsync(int userId);
        Task<Candidate?> GetCandidateWithDetailsAsync(int candidateId);
    }
}
