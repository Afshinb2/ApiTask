using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiTask.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {

        private readonly Services.IExchangeProvider _exchangeProvider;

        public ExchangeController(Services.IExchangeProvider exchangeProvider)
        {
            _exchangeProvider = exchangeProvider;
        }

        [HttpGet]
        [Route("{dates}/{currencies}")]
        public async Task<Models.PairResult> Get(string dates, string currencies)
        {
            return await _exchangeProvider.GetDataAsync(dates, currencies); ;
        }

        [HttpGet]
        [Route("{dates}/{base}/{target}")]
        public async Task<Models.PairResult> Get(string dates, string @base, string target)
        {
            return await _exchangeProvider.GetDataAsync(dates, @base, target); ;
        }
    }
}