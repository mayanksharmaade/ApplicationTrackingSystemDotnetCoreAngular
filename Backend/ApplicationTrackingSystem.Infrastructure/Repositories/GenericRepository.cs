using ApplicationTrackingSystem.Infrastructure.Data;
using ApplicationTrackingSytem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> AddAsync(T entity) { await _dbSet.AddAsync(entity); return entity; }
        public Task UpdateAsync(T entity) { _ctx.Entry(entity).State = EntityState.Modified; return Task.CompletedTask; }
        public Task DeleteAsync(T entity) { _dbSet.Remove(entity); return Task.CompletedTask; }
    }
}
