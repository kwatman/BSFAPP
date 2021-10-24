using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BaseRepository<T>
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

      //  public virtual IQueryable<T> GetAll()
       // {
       //     return _appDbContext.Set<T>().AsQueryable();
       // }
    }
}
