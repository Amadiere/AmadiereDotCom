using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amadiere.Blog;
using Amadiere.Blog.Model;
using Amadiere.Blog.Repositories;
using Blog.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Blog.Tests
{
    [TestClass]
    public class ArticleReaderTests
    {
        [TestMethod]
        public void Get_WithValidId_ReturnsArticle()
        {
            // arrange
            int id = 2;
            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(id);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BlogArticle));
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual("My Blog Title 2", result.Title);
        }

        [TestMethod]
        public void Get_WithInvalidId_ReturnsNull()
        {
            // arrange
            int id = 3252351;
            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(id);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_WithValidId_WhenArticleDeleted_ReturnsNull()
        {
            // arrange
            int id = 4;
            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(id);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_WithValidUrlData_ReturnsArticle()
        {
            // arrange
            int year = DateTime.Now.AddDays(-2).Year;
            int month = DateTime.Now.AddDays(-2).Month;
            string slug = "slug-2-goes-here";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(year, month, slug);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BlogArticle));
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("My Blog Title 2", result.Title);
        }

        [TestMethod]
        public void Get_WithValidUrlData_WhenArticleDeleted_ReturnsNull()
        {
            // arrange
            int year = DateTime.Now.AddDays(-4).Year;
            int month = DateTime.Now.AddDays(-4).Month;
            string slug = "slug-4-goes-here";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(year, month, slug);

            // assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void Get_WithMismatchingData_ReturnsNull()
        {
            // arrange
            int year = DateTime.Now.AddDays(-2).AddMonths(-1).Year;
            int month = DateTime.Now.AddDays(-2).AddMonths(-1).Month;
            string slug = "slug-2-goes-here";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(year, month, slug);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_WithInvalidUrlData_ReturnsNull()
        {
            // arrange
            int year = 2015;
            int month = 2;
            string slug = "derrick";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.Get(year, month, slug);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllByTag_WithValidTag_ReturnsArticles()
        {
            // arrange
            string tag = "ASP.NET MVC";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.GetAllByTag(tag);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetAllByTag_WithValidTag_WhenAllArticlesHaveBeenDeleted_ReturnsEmptyList()
        {
            // arrange
            string tag = "PHP";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.GetAllByTag(tag);

            // assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetAllByTag_WithInvalidTag_ReturnsEmptyList()
        {
            // arrange
            string tag = "OMGWTFBBQ";

            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.GetAllByTag(tag);

            // assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetMostRecent_Returns5()
        {
            // arrange
            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var result = articleReader.GetMostRecent();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void GetMostRecent_ReturnsMostRecentlyPublishedFirst()
        {
            // arrange
            var articles = new ArticleListBuilder().Build().Object;
            var mockRepo = new Mock<IBlogRepository>();
            mockRepo.Setup(x => x.Articles).Returns(articles);

            var articleReader = new ArticleReader(mockRepo.Object);

            // act
            var actualResult = articleReader.GetMostRecent();
            var expectedResult = actualResult.OrderByDescending(x => x.PublishedOn);

            // assert
            Assert.AreEqual(expectedResult.ElementAt(0).Id, actualResult.ElementAt(0).Id);
            Assert.AreEqual(expectedResult.ElementAt(1).Id, actualResult.ElementAt(1).Id);
            Assert.AreEqual(expectedResult.ElementAt(2).Id, actualResult.ElementAt(2).Id);
            Assert.AreEqual(expectedResult.ElementAt(3).Id, actualResult.ElementAt(3).Id);
            Assert.AreEqual(expectedResult.ElementAt(4).Id, actualResult.ElementAt(4).Id);
        }
    }
}
