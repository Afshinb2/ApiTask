using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ApiTask.Services
{
    public class WebDataProvider : IWebDataProvider
    {

        private readonly HttpClient _client;

        public WebDataProvider(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            //Loads base uri from the configuration and sets it on http client
            _client.BaseAddress = new Uri(configuration["WebDataProviderBaseUri"]);
        }

        public Task<string> GetApiResultAsync(string date, string baseCurrency, string targetCurrency)
        {
            //Prepare query
            var query = HttpUtility.ParseQueryString("");

            query["base"] = baseCurrency;
            query["symbols"] = targetCurrency;

            //Get result as string
            return _client.GetStringAsync(date + "?" + query.ToString());
        }
    }
}