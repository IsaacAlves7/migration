using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trp.Service.Cache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        T Get<T>(string key);
        Task SetAsync(string key, object data, TimeSpan timeSpan);
        bool IsSet(string key);
    }
}
