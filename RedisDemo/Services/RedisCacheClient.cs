using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedisDemo.Models;
using ServiceStack.Redis;

namespace RedisDemo.Services
{
    public class RedisCacheClient : ICacheClient
    {
        private readonly ILogger _logger;

        private readonly IRedisClientsManager _redisClientsManager;

        public RedisCacheClient(IRedisClientsManager redisClientsManager, ILogger<RedisCacheClient> logger)
        {
            _redisClientsManager = redisClientsManager;
            _logger = logger;
        }

        public bool Delete(string key)
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<ICacheItem>();
                    item.RemoveEntry(key);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to delete cache item {key} {Ex}", key, ex);
                return false;
            }
        }

        public T Get<T>(string key) where T : ICacheItem
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<T>();
                    var result = item.GetValue(key);

                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to get cache item {key} {Ex}", key, ex);
                return default(T);
            }
        }

        public bool Set<T>(string key, T value, TimeSpan? expiry = null) where T : ICacheItem
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<T>();
                    item.SetValue(key, value, expiry??TimeSpan.FromHours(1));

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to set cache item {key} {Ex}", key, ex);
                return false;
            }
        }
    }

}
