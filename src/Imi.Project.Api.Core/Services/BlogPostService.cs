using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BlogPostService
    {
        protected readonly IBaseRepository<BlogPost> _blogPostRepository;

        public BlogPostService(IBaseRepository<BlogPost> blogPostService)
        {
            _blogPostRepository = blogPostService;
        }

        public IQueryable<BlogPost> GetAll()
        {
            return _blogPostRepository.GetAll();
        }

        public async Task<IEnumerable<BlogPost>> ListAllAsync()
        {
            return await _blogPostRepository.GetAll().ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            return await _blogPostRepository.GetByIdAsync(id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            return await _blogPostRepository.UpdateAsync(blogPost);
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            return await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task<BlogPost> DeleteAsync(BlogPost blogPost)
        {
            return await _blogPostRepository.DeleteAsync(blogPost);
        }
    }
}
