using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Repositories;
using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace KamikazeChicken.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockPostCategory;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listPostCategory;
        private PostCategory _postCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockPostCategory = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockPostCategory.Object, _mockUnitOfWork.Object);

            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID = 1,Name = "PC1",Alias="post-category",Status =true },
                new PostCategory() {ID = 2,Name = "PC2",Alias="post-category",Status =true},
                new PostCategory() {ID = 3,Name = "PC2",Alias="post-category",Status =true}
            };

            _postCategory = new PostCategory()
            {
                ID = 1,
                Name = "PC1",
                Alias = "post-category",
                Status = true
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method, expect return a list<PostCategory>
            _mockPostCategory.Setup(x => x.GetAll(null)).Returns(_listPostCategory);

            //call action

            var result = _postCategoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {

            //call method, return a PostCategory
            _mockPostCategory.Setup(x => x.Add(_postCategory)).Returns((PostCategory p) => {
                p.MetaKeyword = "testPostCategoryServiceCreate";
                return p;
            });
            // call action
            var result = _postCategoryService.Add(_postCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}