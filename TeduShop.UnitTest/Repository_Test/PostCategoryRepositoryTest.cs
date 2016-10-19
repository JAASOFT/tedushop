using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.Repository_Test
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory _DbFactoy;
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            _DbFactoy = new DbFactory();
            _postCategoryRepository = new PostCategoryRepository(_DbFactoy);
            _unitOfWork = new UnitOfWork(_DbFactoy);


        }
        [TestMethod]
        public void PostCategory_Pository_GetAll()
        {
            var listOject = _postCategoryRepository.GetAll().ToList();
            Assert.AreEqual(2, listOject.Count);

         

        }
        [TestMethod]
        public void PostCategory_Repository_Creat()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "Test-Category Alias";
            category.Status = true;
            var result = _postCategoryRepository.Add(category);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }
    }
}
