using System.Collections.Generic;
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
    [Route("api/Companies")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public sealed class CompaniesController : ODataController
    {
        private readonly ICompanyService _companyController;
        public CompaniesController(ICompanyService companyController)
        {
            _companyController = companyController;
        }
        
        /// <summary>
        /// This method retrieves all companies registered on application
        /// </summary>
        /// <returns>List of Company objects</returns>
        /// <response code="200">Company list returned successfully</response>
        [HttpGet]
        [EnableQuery(PageSize = 100)]
        [ProducesResponseType(200)]
        public ActionResult<IQueryable<Company>> GetAllCompanies()
        {
            var companies = _companyController.GetAllCompanies();

            return Ok(companies);
        }
        
        /// <summary>
        /// This method retrieves single client
        /// </summary>
        /// <param name="companyId">Company identification number</param>
        /// <returns>Single Company objects</returns>
        /// <response code="200">Company returned successfully</response>
        /// <response code="404">Company not found</response>
        [HttpGet("{companyId:long}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<ActionResult<Company>> GetCompany(int companyId)
        {
            var company = await _companyController.GetCompany(companyId);

            return company;
        }
    }
}