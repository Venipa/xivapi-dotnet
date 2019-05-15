using System;
using System.Collections.Generic;

namespace XIVApi.AspNetCore
{
    public class XIVApiOptions
    {

#pragma warning disable CS1591
        public XIVApiOptions()
        {
            XIVApi = new ApiKeyOptions();
            XIVApi.SlidingExpirationTime = TimeSpan.FromHours(1);
            XIVApi.RateLimits = new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = XIVApi.ApiKey != null ? 30 : 15
            };
        }

        public ApiKeyOptions XIVApi { get; set; }
    }
#pragma warning restore
}