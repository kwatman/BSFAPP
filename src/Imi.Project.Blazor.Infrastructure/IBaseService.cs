using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public interface IBaseService<T> where T : Base
    {
        IQueryable<T> GetAll(List<T> context);
        Task<T> GetById(List<T> context, Guid id);
        Task<T> Update(List<T> context, T model);
        Task<T> Add(List<T> context, T model);
        Task<T> Delete(List<T> context, Guid id);
    }
}
