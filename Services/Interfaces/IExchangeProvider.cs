using ApiTask.Models;
using System.Threading.Tasks;

namespace ApiTask.Services
{
    public interface IExchangeProvider
    {

        /// <summary>Checks cache and if data is not available calls the external data provider.</summary>
        /// <param name="date">Date formatted as "YYYY-MM-DD".</param>
        /// <param name="currencies">Currency pair formatted as "XXX->YYY".</param>
        /// <returns>Requested data for currency pair.</returns>
        Task<PairResult> GetDataAsync(string dates, string currencies);

        /// <summary>Checks cache and if data is not available calls the external data provider.</summary>
        /// <param name="date">Date formatted as "YYYY-MM-DD".</param>
        /// <param name="baseCurrency">Base currency name.</param>
        /// <param name="targetCurrency">Target currency name.</param>
        /// <returns>Requested data for currency pair.</returns>
        /// 
        Task<PairResult> GetDataAsync(string dates, string baseCurrency, string targetCurrency);

    }
}