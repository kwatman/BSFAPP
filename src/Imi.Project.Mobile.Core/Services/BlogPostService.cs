using Akavache;
using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Services
{
    public class BlogPostService: BaseService<BlogPost>, IBlogPostService
    {
        protected readonly IBaseRepository _baseRepository;
        public BlogPostService(IBaseRepository baseRepository, IBlobCache cache = null) : base(null, cache)
        {
            _baseRepository = baseRepository;
        }
    }
}
