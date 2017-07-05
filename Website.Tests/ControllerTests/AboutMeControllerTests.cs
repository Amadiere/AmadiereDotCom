using System;
using System.Collections.Generic;
using System.Text;
using Amadiere.Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amadiere.Website.Tests.ControllerTests
{
    [TestClass]
    public class AboutMeControllerTests
    {
        [TestMethod]
        public void AboutMeIndex_Returns_ViewResult()
        {
            // Arrange
            var controller = new AboutMeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }
    }
}
