﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVApi.AspNetCore
{
    public class ApiKeyOptions
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the rate limits.
        /// </summary>
        public IDictionary<TimeSpan, int> RateLimits { get; set; }

        /// <summary>
        /// Enables or disables default caching implementation.
        /// </summary>
        public bool UseCache { get; set; }

        /// <summary>
        /// Enables or disables in-memory caching implementation.
        /// </summary>
        public bool UseMemoryCache { get; set; }
        /// <summary>
        /// Enable or disable ASP.NET Core distributed cache implementation for caching
        /// </summary>
        public bool UseDistributedCache { get; set; }
        /// <summary>
        /// Enable or disable memory cache and distributed cache. If enabled, in-memory cache will be at first and distributed as a fallback.
        /// </summary>
        public bool UseHybridCache { get; set; }

        /// <summary>
        /// Sliding expiration time for caching.
        /// </summary>
        public TimeSpan SlidingExpirationTime { get; set; }

        /// <summary>
        /// For static data only: Throws a XIVException instead of delaying the request when the rate limit is reached.
        /// </summary>
        public bool ThrowOnRateLimitedReached { get; set; }
    }
}
