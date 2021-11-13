using Akavache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Services
{
    public class CacheService
    {
        protected IBlobCache _cache;

        public BaseService(IBlobCache cache)
        {
            _cache = cache ?? BlobCache.LocalMachine;
        }
    }
}
