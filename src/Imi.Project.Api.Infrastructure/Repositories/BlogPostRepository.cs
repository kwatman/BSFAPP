using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public async Task<IEnumerable<BlogPost>> SearchAsync(string searchString)
        {
            var blogPosts = await GetAll().Where(p => p.Title.Contains(searchString.Trim().ToUpper())).ToListAsync();

            return blogPosts;
        }
    }
}
