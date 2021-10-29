using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ApiTask.Services.Tests
{
    public class MockWebDataProvider : IWebDataProvider
    {
        public Task<string> GetApiResultAsync(string date, string baseCurrency, string targetCurrency)
        {
            return date switch
            {
                "2018-02-01" => Task.FromResult("{\"motd\":{\"msg\":\"If you or your company use this project or like what we doing, please consider backing us so we can continue maintaining and evolving this project.\",\"url\":\"https://exchangerate.host/#/donate\"},\"success\":true,\"historical\":true,\"base\":\"SEK\",\"date\":\"2018-02-01\",\"rates\":{\"NOK\":0.978148}}"),
                "2018-02-15" => Task.FromResult("{\"motd\":{\"msg\":\"If you or your company use this project or like what we doing, please consider backing us so we can continue maintaining and evolving this project.\",\"url\":\"https://exchangerate.host/#/donate\"},\"success\":true,\"historical\":true,\"base\":\"SEK\",\"date\":\"2018-02-15\",\"rates\":{\"NOK\":0.979845}}"),
                _ => Task.FromResult("{\"motd\":{\"msg\":\"If you or your company use this project or like what we doing, please consider backing us so we can continue maintaining and evolving this project.\",\"url\":\"https://exchangerate.host/#/donate\"},\"success\":true,\"historical\":true,\"base\":\"SEK\",\"date\":\"2018-03-01\",\"rates\":{\"NOK\":0.952702}}"),
            };
        }
    }
}