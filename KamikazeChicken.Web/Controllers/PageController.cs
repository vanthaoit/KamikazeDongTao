using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using KamikazeChicken.Web.Models;
using System.Web.Mvc;

namespace KamikazeChicken.Web.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public ActionResult Index(string alias)
        {
            var modelData = _pageService.GetByAlias(alias);
            var viewModelData = AutoMapper.Mapper.Map<Page, PageViewModel>(modelData);
            return View(viewModelData);
        }
    }
}