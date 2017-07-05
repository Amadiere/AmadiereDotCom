using System;
using System.Collections.Generic;
using System.Text;
using Amadiere.Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amadiere.Website.Tests.ControllerTests
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public void BlogIndex_Returns_DefaultViewResult()
        {
            // Arrange
            var controller = new BlogController();

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
            var controller = new BlogController();

            // Act
            var result = controller.Article(2017, 4, "slug") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }
    }
}
