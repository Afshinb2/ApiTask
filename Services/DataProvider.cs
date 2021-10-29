using ApiTask.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiTask.Services
{
    public class DataProvider : IDataProvider
    {

        private readonly IWebDataProvider _webDataProvider;

        public DataProvider(IWebDataProvider webDataProvider)
        {
            _webDataProvider = webDataProvider;
        }

        public async Task<double> GetByDateAsync(string date, string baseCurrency, string targetCurrency)
        {
            //Get json result from our web provider as string
            var apiResponseString = await _webDataProvider.GetApiResultAsync(date, baseCurrency, targetCurrency);

            //Deserialize json into an entity
            var result = JsonConvert.DeserializeObject<WebApiResponse>(apiResponseString);
                
            //Return exchange rate for our pair
            return result.rates[targetCurrency];
        }
    }
}