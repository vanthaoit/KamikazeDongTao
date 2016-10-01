using KamikazeChicken.Common;
using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using KamikazeChicken.Web.Infrastructure.Core;
using KamikazeChicken.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KamikazeChicken.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        public ActionResult Category(int productCategoryId, int page=1,string sort="")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var productModelData = _productService.GetListProductByCategoryIdPaging(productCategoryId, page, pageSize,out totalRow,sort);
            var productViewModelData = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModelData);
            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>
            {
                
                Page = page,
                TotalPages = totalPages,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                TotalCount = totalRow,
                Items = productViewModelData

            };

            var productCategoryModelData = _productCategoryService.GetById(productCategoryId);
            ViewBag.productCategoryViewModelData = AutoMapper.Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategoryModelData);

            return View(paginationSet);
        }

        public ActionResult Detail(int productId)
        {
            var productDetailModelData = _productService.GetById(productId);
            var productDetailViewModelData = AutoMapper.Mapper.Map<Product, ProductViewModel>(productDetailModelData);

            var productRelatedModelData = _productService.GetRelatedProducts(productId,6);
            ViewBag.RelatedProducts = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productRelatedModelData);

            List<string> listMoreImages = new JavaScriptSerializer().Deserialize<List<string>>(productDetailViewModelData.MoreImages);
            
             ViewBag.ListMoreImages = listMoreImages;

            return View(productDetailViewModelData);
        }

        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {

            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var productModelData = _productService.Search(keyword, page, pageSize, out totalRow, sort);
            var productViewModelData = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModelData);

            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>
            {

                Page = page,
                TotalPages = totalPages,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                TotalCount = totalRow,
                Items = productViewModelData

            };

    
            ViewBag.keyword = keyword;

            return View(paginationSet);
        }

        public JsonResult GetListProductByName(string keyword)
        {
            var modelData = _productService.GetListProductByName(keyword);
            return Json(
                new
                {
                    data = modelData
                }
                ,JsonRequestBehavior.AllowGet);
        }
    }
}