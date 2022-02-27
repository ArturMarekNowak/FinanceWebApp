using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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
        ///     This method retrieves all companies registered on application
        /// </summary>
        /// <returns>List of Company objects</returns>
        /// <response code="200">Company list returned successfully</response>
        [HttpGet]
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
        /// <param name="companyId">Company identification number</param>
        /// <returns>Single Company objects</returns>
        /// <response code="200">Company returned successfully</response>
        /// <response code="404">Company not found</response>
        [HttpGet("{companyId:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Currency>> GetCurrency(int companyId)
        {
            var currency = await _currenciesController.GetCurrency(companyId);

            return Ok(currency);
        }
    }
}