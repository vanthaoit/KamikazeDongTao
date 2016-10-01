using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using KamikazeChicken.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

namespace KamikazeChicken.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,
                                IProductService productService, 
                                ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        public ActionResult Index()
        { 

            var listSlideModelData = _commonService.GetSlides();
            var listSlideViewModelData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(listSlideModelData);
            var homeViewModelData = new HomeViewModel();
            homeViewModelData.Slides = listSlideViewModelData;

            var lastestProductModelData = _productService.GetLastest(3);
            var topProductModelData = _productService.GetTopProduct(3);
            var lastestProductViewModelData = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(lastestProductModelData);
            var topProductViewModelData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topProductModelData);
            homeViewModelData.LastestProducts = lastestProductViewModelData;
            homeViewModelData.TopSaleProducts = topProductViewModelData;

            return View(homeViewModelData);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult ProductCategory()
        {
            var listProductCategoryModelData = _productCategoryService.GetAll();
            var listProductCategoryViewModelData = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listProductCategoryModelData);
            return PartialView(listProductCategoryViewModelData);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModelData = _commonService.GetFooter();
            var footerViewModelData = AutoMapper.Mapper.Map<Footer, FooterViewModel>(footerModelData);
            return PartialView(footerViewModelData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}