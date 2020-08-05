﻿using System;
namespace RedisClusterTemplate.Models
{
    public class CachedItem : ICacheItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
