using System;
using Microsoft.AspNetCore.Mvc;
using RedisClusterTemplate.Models;
using RedisClusterTemplate.Services;
using ServiceStack.Redis;

namespace RedisClusterTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : Controller
    {
        private readonly ICacheClient _cache;

        public RedisController(ICacheClient cache)
        {
            _cache = cache;
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("Healthy!");
        }

        [HttpGet("get/{key}")]
        public IActionResult GetCachedItem(string key)
        {
            var result = _cache.Get<CachedItem>(key);
            return Ok(result);
        }

        [HttpPost("set/{key}")]
        public IActionResult SetCachedItem(string key, [FromBody]CachedItem item)
        {
            var result = _cache.Set<CachedItem>(key, item);

            return Ok(result);
        }

        [HttpDelete("delete/{key}")]
        public IActionResult DeleteCachedItem(string key)
        {
            var result = _cache.Delete(key);

            return Ok(result);
        }
    }
}
