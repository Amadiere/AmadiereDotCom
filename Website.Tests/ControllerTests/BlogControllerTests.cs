using System;
using System.Collections.Generic;
using System.Text;
using Amadiere.Blog;
using Amadiere.Blog.Model;
using Amadiere.Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Amadiere.Website.Tests.ControllerTests
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public void BlogIndex_Returns_DefaultViewResult()
        {
            // Arrange
            var mockArticleReader = new Mock<IArticleReader>();
            mockArticleReader.Setup(x => x.Get(2017, 4, "slug")).Returns(GetArticle());
            var controller = new BlogController(mockArticleReader.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }

        [TestMethod]
        public void BlogArticle_Returns_DefaultViewResult()
        {
            // Arrange
            var mockArticleReader = new Mock<IArticleReader>();
            mockArticleReader.Setup(x => x.Get(2017, 4, "slug")).Returns(GetArticle());
            var controller = new BlogController(mockArticleReader.Object);

            // Act
            var result = controller.Article(2017, 4, "slug") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }

        [TestMethod]
        public void BlogArticle_WithNullParam_RedirectsToIndexAction()
        {
            // Arrange
            var mockArticleReader = new Mock<IArticleReader>();
            mockArticleReader.Setup(x => x.Get(2017, 4, "slug")).Returns(GetArticle());
            var controller = new BlogController(mockArticleReader.Object);

            // Act
            var result = controller.Article(null, null, "slug");
            var redirect = result as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.ActionName);
            Assert.IsNull(redirect.ControllerName); // same controller...
        }

        [TestMethod]
        public void BlogArticle_WithAcceptableParams_WithNoArticle_RedirectsToIndexAction()
        {
            // Arrange
            var mockArticleReader = new Mock<IArticleReader>();
            mockArticleReader.Setup(x => x.Get(2017, 4, "slug")).Returns(GetArticle());
            var controller = new BlogController(mockArticleReader.Object);

            // Act
            var result = controller.Article(2017, 4, "derrick-the-god");
            var redirect = result as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.ActionName);
            Assert.IsNull(redirect.ControllerName); // same controller...
        }

        private BlogArticle GetArticle()
        {
            var dateOfPost = new DateTime(2017, 4, 24, 17, 45, 0);
            return new BlogArticle()
            {
                Id = 1,
                PublishedOn = dateOfPost,
                CreatedOn = dateOfPost,
                DeletedOn = null,
                LastModifiedOn = dateOfPost,
                ViewName = "AMA00001-ViewName",
                Month = dateOfPost.Month,
                Year = dateOfPost.Year,
                Slug = "slug-1-goes-here",
                Tags = new [] { "Elixir", "Erlang" },
                Title = "My Blog Title 1"
            };
        }
    }
}
