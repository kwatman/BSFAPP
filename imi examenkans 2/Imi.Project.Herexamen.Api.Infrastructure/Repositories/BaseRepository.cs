using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Imi.Project.Herexamen.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Herexamen.Api.Infrastucture.Repositories
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

        public virtual async Task<ServiceResponse<IEnumerable<T>>> ListAllAsync()
        {
            ServiceResponse<IEnumerable<T>> response = new ServiceResponse<IEnumerable<T>>();
            var data = await _ctx.Set<T>().ToListAsync();
            response.Data = data;

            return response;
        }

        public virtual async Task<ServiceResponse<T>> GetByIdAsync(Guid id)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            var data = await _ctx.Set<T>().SingleOrDefaultAsync(t => t.Id.Equals(id));
            response.Data = data;

            return response;
        }

        public async Task<ServiceResponse<T>> CreateAsync(T entity)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            response.Data = entity;

            return response;
        }

        public async Task<ServiceResponse<T>> UpdateAsync(T entity)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
            response.Data = entity;

            return response;
        }

        public async Task<ServiceResponse<T>> DeleteAsync(T entity)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
            response.Data = entity;

            return response;
        }
    }
}