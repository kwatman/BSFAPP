using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.MockServices
{
    public class BaseMockService<T>: IBaseService<T> where T : Base
    {
        public virtual IQueryable<T> GetAll(List<T> context)
        {
            return context.AsQueryable();
        }

        public async Task<T> GetById(List<T> context, Guid id)
        {
            var model = context.FirstOrDefault(m => m.Id == id);
            return await Task.FromResult(model);
        }

        public async Task<T> Add(List<T> context, T model)
        {
            context.Add(model);
            return await Task.FromResult(model);
        }

        public async Task<T> Update(List<T> context, T model)
        {
            var modelToUpdate = context.FirstOrDefault(m => m.Id == model.Id);
            context.Remove(modelToUpdate);
            context.Add(model);
            return await Task.FromResult(model);
        }

        public async Task<T> Delete(List<T> context, Guid id)
        {
            var modelToDelete = context.FirstOrDefault(m => m.Id == id);
            context.Remove(modelToDelete);
            return await Task.FromResult(modelToDelete);
        }
    }
}
