using System;
using Microsoft.AspNetCore.Mvc;
using RedisClusterTemplate.Models;
using ServiceStack.Redis;

namespace RedisClusterTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : Controller
    {
        private readonly IRedisClientsManager _redisClientsManager;

        public RedisController(IRedisClientsManager redisClientsManager)
        {
            _redisClientsManager = redisClientsManager;
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("Healthy!");
        }

        [HttpGet("get/{key}")]
        public IActionResult GetCachedItem(string key)
        {
            using (IRedisClient redis = _redisClientsManager.GetClient())
            {
                var cached = redis.As<CachedItem>();
                var result = cached.GetById(key);

                if (result == null)
                {
                    return Ok("Not Found");
                }

                return Ok(result);
            }
        }

        [HttpPost("set/{key}/{val}")]
        public IActionResult SetCachedItem(string key, string val)
        {
            using (IRedisClient redis = _redisClientsManager.GetClient())
            {
                var cached = redis.As<CachedItem>();

                cached.Store(new CachedItem
                {
                    Id = key,
                    Value = val
                });

                return Ok("Success");
            }
        }
    }
}
