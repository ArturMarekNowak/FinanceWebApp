using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class CompaniesController : ControllerBase
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
        [HttpGet("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            return await _companyController.GetAllCompanies();
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
            var user = await _companyController.GetCompany(companyId);

            return user;
        }
    }
}