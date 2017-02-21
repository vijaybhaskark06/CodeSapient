using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GloboMart.Client.Models;
using GloboMart.Client.Controllers;

namespace GloboMart.Client.Tests.Controllers
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void TestMethodIndex()
        {
            // Arrange
            var apiMock = new Mock<IFooApi>();
            apiMock.Setup(api => api.Post(It.IsAny<Product>())).ReturnsAsync(new OkNegotiatedContentResult<Product>(new Result(), new FooApi()));

            // Act
            var testObject = new Product(apiMock.Object);
            var viewResult = testObject.Post(new Product()).Result as Product;
            var result = (Product)viewResult.Model;

            // Assert
            Assert.AreEqual(2, result.Product);

        }
    }
}
