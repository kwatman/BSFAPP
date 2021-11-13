using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Services
{
    public class ProductService
    {
        private readonly IBaseRepository _baseRepository;

        public ProductService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }


    }
}
