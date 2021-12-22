using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBlogPostService
    {
        IQueryable<BlogPost> GetAll();
        Task<IEnumerable<BlogPost>> ListAllAsync();
        Task<BlogPost> GetByIdAsync(Guid id);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> DeleteAsync(BlogPost blogPost);
    }
}
