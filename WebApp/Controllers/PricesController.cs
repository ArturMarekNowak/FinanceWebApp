using System.Linq;
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
    [Route("api/Prices")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public sealed class PricesController : Controller
    {
        private readonly IPriceService _pricesService;

        public PricesController(IPriceService pricesService)
        {
            _pricesService = pricesService;
        }

        /// <summary>
        ///     This method retrieves all currencies prices
        /// </summary>
        /// <returns>List of CompanyPrice objects</returns>
        /// <response code="200">CompanyPrice list returned successfully</response>
        [HttpGet]
        [ODataAttributeRouting]
        [EnableQuery(PageSize = 100)]
        [ProducesResponseType(200)]
        public ActionResult<IQueryable<Price>> GetAllPrices(string symbol)
        {
            var prices = _pricesService.GetAllPrices(symbol);

            return Ok(prices);
        }
    }
}