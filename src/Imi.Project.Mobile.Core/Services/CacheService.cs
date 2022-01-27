using Akavache;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services
{
    public class CacheService
    {
        protected IBlobCache _cache;

        public CacheService(IBlobCache cache)
        {
            _cache = cache ?? BlobCache.LocalMachine;
        }

        public async Task<T> ReadFromCache<T>(string cacheIdentifier)
        {
            try
            {
                T type = await _cache.GetObject<T>(cacheIdentifier);
                return type;
            }
            catch (KeyNotFoundException)
            {
                return default(T);
            }
        }
    }
}
