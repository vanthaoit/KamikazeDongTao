using KamikazeChicken.Service;
using KamikazeChicken.Web.Infrastructure.Core;
using System.Web.Http;

namespace KamikazeChicken.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("testmethod")]
        public string TestMethod()
        {
            return "Xin chào, Kamikaze Chicken !!";
        }
    }
}