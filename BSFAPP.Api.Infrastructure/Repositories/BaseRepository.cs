using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BSFAPP.Api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected readonly AppDbContext _ctx;

        public BaseRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            var data = await _ctx.Set<T>().ToListAsync();

            return data;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var data = await _ctx.Set<T>().SingleOrDefaultAsync(t => t.Id.Equals(id));

            return data;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }
    }
}