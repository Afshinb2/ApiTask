using System.Threading.Tasks;

namespace ApiTask.Services
{
    public interface IDataProvider
    {

        /// <summary>Calls the main data provider and returns the result.</summary>
        /// <param name="date">Date formatted as "YYYY-MM-DD".</param>
        /// <param name="baseCurrency">Base currency name.</param>
        /// <param name="targetCurrency">Target currency name.</param>
        /// <returns>Exchange rate of a currency pair in a specific date.</returns>
        Task<double> GetByDateAsync(string date, string baseCurrency, string targetCurrency);

    }
}