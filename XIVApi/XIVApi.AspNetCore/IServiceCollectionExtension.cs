using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using XIVApi.Http;
using XIVApi.Caching;

namespace XIVApi.AspNetCore
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds and configures XIVAPI's services
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddXIVApi(this IServiceCollection serviceCollection, Action<XIVApiOptions> options)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            var xivApiOptions = new XIVApiOptions();
            options(xivApiOptions);

            var requester = new Requester(xivApiOptions.XIVApi.ApiKey);

            if (xivApiOptions.XIVApi.UseMemoryCache)
                serviceCollection.AddSingleton<ICache, MemoryCache>();
            else if (xivApiOptions.XIVApi.UseDistributedCache)
                serviceCollection.AddSingleton<ICache, DistributedCache>();
            else if (xivApiOptions.XIVApi.UseHybridCache)
                serviceCollection.AddSingleton<ICache, HybridCache>(
                    serviceProvider => new HybridCache(
                        serviceProvider.GetRequiredService<IMemoryCache>(),
                        serviceProvider.GetRequiredService<IDistributedCache>(),
                        xivApiOptions.XIVApi.SlidingExpirationTime));
            else if (xivApiOptions.XIVApi.UseCache)
                serviceCollection.AddSingleton<ICache, Cache>();
            else
                serviceCollection.AddSingleton<ICache, PassThroughCache>();

            serviceCollection.AddSingleton<IXIVApi>(serviceProvider =>
                new XIVApi(requester, serviceProvider.GetRequiredService<ICache>()));
            

            return serviceCollection;
        }
    }
}
