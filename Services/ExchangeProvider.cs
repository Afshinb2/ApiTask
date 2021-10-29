using ApiTask.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTask.Services
{
    public class ExchangeProvider : IExchangeProvider
    {

        private readonly IDataProvider _dataProvider;
        private readonly ICacheProvider _cacheProvider;
        private readonly IConfiguration _configuration;

        public ExchangeProvider(IDataProvider dataProvider, ICacheProvider cacheProvider, IConfiguration configuration)
        {
            _dataProvider = dataProvider;
            _cacheProvider = cacheProvider;
            _configuration = configuration;
        }

        public Task<PairResult> GetDataAsync(string dates, string currencies)
        {
            //Split pair using "->" string
            var currencyList = currencies.Split(_configuration["CurrencySplitChar"], StringSplitOptions.RemoveEmptyEntries);

            var baseCurrency = currencyList[0];
            var targetCurrency = currencyList[1];

            return GetDataAsync(dates, baseCurrency, targetCurrency);
        }

        public async Task<PairResult> GetDataAsync(string dates, string baseCurrency, string targetCurrency)
        {
            var datesList = dates.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var result = new PairResult();
            
            //Used to store all values and calculate average later.
            var allValues = new List<double>();

            foreach (string date in datesList)
            {

                //Load data for this date
                var dateResult = await GetResultItem(date.Trim(), baseCurrency.Trim(), targetCurrency.Trim());

                allValues.Add(dateResult.Rate);

                //Check against min rate entity
                if (result.MinRate is null || result.MinRate.Rate > dateResult.Rate)
                {
                    result.MinRate = dateResult;
                }

                //Check against max rate entity
                if (result.MaxRate is null || result.MaxRate.Rate < dateResult.Rate)
                {
                    result.MaxRate = dateResult;
                }

            }

            //Calculate average
            result.AvgRate = allValues.Average();

            return result;
        }

        private async Task<DateRate> GetResultItem(string date, string baseCurrency, string targetCurrency)
        {
            //Load data from cache
            var dateResult = _cacheProvider.GetData(date, baseCurrency, targetCurrency);

            if (dateResult is null)
            {
                //Create new entity if cache is empty
                dateResult = new DateRateCache
                {
                    Date = date,
                    BaseCurrency = baseCurrency,
                    TargetCurrency = targetCurrency,
                    //Call external API to get exchange rate
                    Rate = await _dataProvider.GetByDateAsync(date, baseCurrency, targetCurrency)
                };

                //Add data to cache
                _cacheProvider.AddData(dateResult);
            }

            return dateResult;
        }
    }
}