using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ApiTask.Services.Tests
{
    [TestClass()]
    public class ExchangeProviderTests
    {
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var myConfiguration = new Dictionary<string, string>
                    {
                        {"CurrencySplitChar", "->"}
                    };

                    _config = new ConfigurationBuilder()
                        .AddInMemoryCollection(myConfiguration)
                        .Build();
                }

                return _config;
            }
        }

        private ServiceProvider _serviceProvider;

        [TestInitialize]
        public void TestInit()
        {

            var services = new ServiceCollection();

            services.AddTransient<IWebDataProvider, MockWebDataProvider>();
            services.AddTransient<IDataProvider, DataProvider>();
            services.AddTransient<IExchangeProvider, ExchangeProvider>();
            services.AddTransient<ICacheProvider, InMemoryCacheProvider>();

            services.AddSingleton<IConfiguration>(Configuration);

            _serviceProvider = services.BuildServiceProvider();


        }

        [TestMethod()]
        public async Task GetDataAsyncTest()
        {
            var exchangeProvider = _serviceProvider.GetService<IExchangeProvider>();

            var testResult = await exchangeProvider.GetDataAsync("2018-02-01, 2018-02-15, 2018-03-01", "SEK->NOK");

            Assert.AreEqual(testResult.MinRate.Date, "2018-03-01");
            Assert.AreEqual(testResult.MinRate.Rate, 0.952702);

            Assert.AreEqual(testResult.MaxRate.Date, "2018-02-15");
            Assert.AreEqual(testResult.MaxRate.Rate, 0.979845);

            Assert.AreEqual(testResult.AvgRate, 0.9702316666666667);
        }
    }
}