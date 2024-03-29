﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVApi.Caching;

namespace XIVApi.AspNetCore
{
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly List<object> _usedKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _usedKeys = new List<object>();
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _memoryCache.Set(key, value, slidingExpiry);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _memoryCache.Set(key, value, absoluteExpiry);
        }

        /// <inheritdoc />
        public void Clear()
        {
            foreach (var usedKey in _usedKeys)
            {
                _memoryCache.Remove(usedKey);
                _usedKeys.Remove(usedKey);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            _memoryCache.TryGetValue(key, out TV output);
            return output;
        }

        public void Remove<TK>(TK key)
        {
            _memoryCache.Remove(key);
        }
    }
}
