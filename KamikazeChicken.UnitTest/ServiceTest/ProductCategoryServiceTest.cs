using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Reponsitories;
using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace KamikazeChicken.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductCategoryServiceTest
    {
        private Mock<IProductCategoryRepository> _mockProductCategory;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductCategoryService _productCategoryService;
        private List<ProductCategory> _listProductCategory;
        private ProductCategory _productCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockProductCategory = new Mock<IProductCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _productCategoryService = new ProductCategoryService(_mockProductCategory.Object, _mockUnitOfWork.Object);

            _listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {ID = 1,Name = "PC1",Alias="product-category",Status =true },
                new ProductCategory() {ID = 2,Name = "PC2",Alias="product-category",Status =true},
                new ProductCategory() {ID = 3,Name = "PC2",Alias="product-category",Status =true}
            };

            _productCategory = new ProductCategory()
            {
                ID = 1,
                Name = "PC1",
                Alias = "product-category",
                Status = true
            };
        }

        [TestMethod]
        public void ProductCategory_Service_GetAll()
        {
            //setup method, expect return a list<ProductCategory>
            _mockProductCategory.Setup(x => x.GetAll(null)).Returns(_listProductCategory);

            //call action

            var result = _productCategoryService.GetAll() as List<ProductCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void ProductCategory_Service_Create()
        {
            //call method, return a ProductCategory
            _mockProductCategory.Setup(x => x.Add(_productCategory)).Returns((ProductCategory p) =>
            {
                p.MetaKeyword = "testProductCategoryServiceCreate";
                return p;
            });
            // call action
            var result = _productCategoryService.Add(_productCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}