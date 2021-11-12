using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockApp.Models;

namespace MockApp.Services
{
    public interface ICompanyService
    {
        IEnumerable<CompanyShare> Get();
    }
}
