using ApplicationTrackingSystem.Infrastructure.Data;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using ApplicationTrackingSytem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Infrastructure.Repositories
{
    public class CandidateRepository: GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext ctx) : base(ctx) { }
        

        public Task<Candidate?> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate?> GetCandidateWithDetailsAsync(int candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
