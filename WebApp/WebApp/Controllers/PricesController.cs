using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/Prices")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public sealed class PricesController : ODataController
    {
        private readonly IPriceService _priceController;
        
        public PricesController(IPriceService priceController)
        {
            _priceController = priceController;
        }
        
        /// <summary>
        /// This method retrieves all companies prices 
        /// </summary>
        /// <returns>List of CompanyPrice objects</returns>
        /// <response code="200">CompanyPrice list returned successfully</response>
        [HttpGet]
        [EnableQuery(PageSize = 100)]
        [ProducesResponseType(200)]
        public ActionResult<IQueryable<CompanyPrice>> GetAllCompanies()
        {
            var companies = _priceController.GetAllPrices();

            return Ok(companies);
        }
    }
}