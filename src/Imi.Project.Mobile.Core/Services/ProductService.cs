using Akavache;
using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Services
{
    public class ProductService : BaseService<Product>
    {
        private readonly IBaseRepository _baseRepository;

        public ProductService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
