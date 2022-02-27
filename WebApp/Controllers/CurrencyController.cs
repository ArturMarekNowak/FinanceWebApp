using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    [ApiController]
    [ActionsFilter]
    [Route("api/Currencies")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public sealed class CurrenciesController : Controller
    {
        private readonly ICurrenciesService _currenciesController;

        public CurrenciesController(ICurrenciesService currenciesController)
        {
            _currenciesController = currenciesController;
        }

        /// <summary>
        ///     This method retrieves all currencies registered on application
        /// </summary>
        /// <returns>List of Currency objects</returns>
        /// <response code="200">Currency list returned successfully</response>
        [HttpGet]
        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [ProducesResponseType(200)]
        public ActionResult<IQueryable<Currency>> GetAllCurrencies()
        {
            var currencies = _currenciesController.GetAllCurrencies();

            return Ok(currencies);
        }

        /// <summary>
        ///     This method retrieves single client
        /// </summary>
        /// <param name="currencyId">Currency identification number</param>
        /// <returns>Single Currency objects</returns>
        /// <response code="200">Currency returned successfully</response>
        /// <response code="404">Currency not found</response>
        [HttpGet("{currencyId:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Currency>> GetCurrency(int currencyId)
        {
            var currency = await _currenciesController.GetCurrency(currencyId);

            return Ok(currency);
        }
    }
}