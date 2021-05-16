using FinanceWebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FinanceWebApp.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
