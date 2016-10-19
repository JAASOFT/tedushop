using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TeduShop.Data.Repositories;
using TeduShop.Data.Infrastructure;
using TeduShop.Service;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.Service_Test
{
    [TestClass]
    public class PostCategoryServiceTest

    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listCategory;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockRepository.Object,_mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID=4,Name="Category 4",Status=true },
                new PostCategory() {ID=5,Name="Category 5",Status=true },
                new PostCategory() {ID=6,Name="Category 6",Status=true }

            };

        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);
            //call action
            var result = _postCategoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

        }
        public void PostCategory_Service_Add()
        {

        }
    }
}
