using ApiTask.Models;
using System.Collections.Generic;

namespace ApiTask.Services
{
    public class InMemoryCacheProvider : ICacheProvider
    {

        private static readonly Dictionary<int, DateRateCache> _cache = new();

        public DateRateCache GetData(string date, string baseCurrency, string targetCurrency)
        {
            var cacheKey = GetCacheKey(date, baseCurrency, targetCurrency);

            //Return the cached item if it is available in our cache
            if (_cache.ContainsKey(cacheKey))
            {
                return _cache[cacheKey];
            } else
            {
                return null;
            }
        }

        public void AddData(DateRateCache value)
        {
            var cacheKey = GetCacheKey(value);

            _cache.Add(cacheKey, value);
        }

        private static int GetCacheKey(DateRateCache value)
        {
            return GetCacheKey(value.Date, value.BaseCurrency, value.TargetCurrency);
        }

        private static int GetCacheKey(string date, string baseCurrency, string targetCurrency)
        {
            //Generate a cache key based on all parameters
            return (date, baseCurrency, targetCurrency).GetHashCode();
        }

    }

}