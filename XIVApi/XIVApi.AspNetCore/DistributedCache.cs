using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using XIVApi.Caching;

namespace XIVApi.AspNetCore
{
    /// <summary>
    /// Implementation of ICache with AspNetCore's distributed cache
    /// </summary>
    public class DistributedCache : ICache
    {
        private readonly IDistributedCache _distributed;
        private readonly List<object> _usedKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public DistributedCache(IDistributedCache memoryCache)
        {
            _distributed = memoryCache;
            _usedKeys = new List<object>();
        }

        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _distributed.SetJson(key.ToString(), value, slidingExpiry);
        }

        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _distributed.SetJson(key.ToString(), value, absoluteExpiry);
        }

        public void Clear()
        {
            foreach (var usedKey in _usedKeys)
            {
                _distributed.Remove(usedKey.ToString());
                _usedKeys.Remove(usedKey);
            }
        }

        public TV Get<TK, TV>(TK key) where TV : class
        {
            return _distributed.GetJson<TV>(key.ToString());
        }

        public void Remove<TK>(TK key)
        {
            _distributed.Remove(key.ToString());
        }
    }
}