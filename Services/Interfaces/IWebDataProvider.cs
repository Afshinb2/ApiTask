using System.Threading.Tasks;

namespace ApiTask.Services
{
    public interface IWebDataProvider
    {
        /// <summary>Calls the external API endpoint and returns the result.</summary>
        /// <param name="date">Date formatted as "YYYY-MM-DD".</param>
        /// <param name="baseCurrency">Base currency name.</param>
        /// <param name="targetCurrency">Target currency name.</param>
        /// <returns>A string containing json data.</returns>
        Task<string> GetApiResultAsync(string date, string baseCurrency, string targetCurrency);

    }
}