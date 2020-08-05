using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RedisDemo.Models;

namespace RedisDemo.Services
{
    public interface ICacheClient
    {
        bool Delete(string key);

        T Get<T>(string key) where T : ICacheItem;

        bool Set<T>(string key, T value, TimeSpan? expiry = null) where T : ICacheItem;
    }

}
