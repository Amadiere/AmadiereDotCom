using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amadiere.Blog.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blog.Tests.RepositoriesTests
{
    [TestClass]
    public class BlogRepositoryTests
    {
        [TestMethod]
        public void Contructor_LoadsArticlesFromFile()
        {
            // arrange & act
            var blogRepository = new BlogRepository();
            
            // assert
            Assert.IsNotNull(blogRepository.Articles);
            Assert.IsTrue(blogRepository.Articles.Count() > 0);
        }
    }
}
