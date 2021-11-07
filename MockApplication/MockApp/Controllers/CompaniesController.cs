using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockApp.Services;
using MockApp.Models;

namespace MockApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyShare>> Get()
        {
            var companies = _companyService.Get();
            return Ok(companies);
        }

    }
}
