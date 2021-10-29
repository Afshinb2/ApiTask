using ApiTask.Models;

namespace ApiTask.Services
{
    public interface ICacheProvider
    {

        /// <summary>Get data already available in cache.</summary>
        /// <param name="date">Date formatted as "YYYY-MM-DD".</param>
        /// <param name="baseCurrency">Base currency name.</param>
        /// <param name="targetCurrency">Target currency name.</param>
        /// <returns>Returns null if data is not available.</returns>
        DateRateCache GetData(string date, string baseCurrency, string targetCurrency);

        /// <summary>Add data to cache.</summary>
        /// <param name="value">Item to cache.</param>
        void AddData(DateRateCache value);

    }
}