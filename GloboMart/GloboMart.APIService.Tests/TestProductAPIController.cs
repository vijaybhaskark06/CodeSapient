using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboMart.APIService.Models;
using GloboMart.APIService.Controllers;
using System.Web.Http.Results;
using System.Net;
using GloboMart.APIService.DataAccessRepository;
namespace GloboMart.APIService.Tests
{
    [TestClass]

    public class TestProductAPIController
    {

        [TestMethod]

        public void PostItem_ShouldReturnSameItem()
        {

            var controller = new ProductAPIController(new IDataAccessRepository<Product, 1>());

            var item = GetDemoProduct();

            var result =

                //controller.PostItem(Product) as CreatedAtRouteNegotiatedContentResult<Product>;
                controller.Post(Product) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.RouteName, "DefaultApi");

            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);

            Assert.AreEqual(result.Content.Name, item.ItemName);

        }

        [TestMethod]

        public void PutItem_ShouldReturnStatusCode()
        {

            var controller = new ProductAPIController(new TestUnitTestMockingConext());

            var item = GetDemoProduct();

            var result = controller.Put(item.Id, item) as StatusCodeResult;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);

        }

        [TestMethod]

        public void PutItem_ShouldFail_WhenDifferentID()
        {

            var controller = new ProductAPIController(new TestUnitTestMockingConext());

            var badresult = controller.PutItem(999, GetDemoItem());

            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));

        }

        [TestMethod]

        public void GetItem_ShouldReturnItemWithSameID()
        {

            var context = new TestUnitTestMockingConext();

            context.Items.Add(GetDemoProduct());

            var controller = new ProductAPIController(context);

            var result = controller.Get(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);

            Assert.AreEqual(3, result.Content.ID);

        }

        [TestMethod]

        public void GetItems_ShouldReturnAllItems()
        {

            var context = new TestUnitTestMockingConext();

            context.Items.Add(new Product { Id= 1, Name = "Demo1", Price = 20 });

            context.Items.Add(new Product { Id = 2, Name = "Demo2", Price = 30 });

            context.Items.Add(new Product { Id = 3, Name = "Demo3", Price = 40 });

            var controller = new ProductAPIController(context);

            var result = controller.Get() as TestItemDbSet;

            Assert.IsNotNull(result);

            Assert.AreEqual(3, result.Local.Count);

        }

        [TestMethod]

        public void DeleteItem_ShouldReturnOK()
        {

            var context = new TestUnitTestMockingConext();

            var item = GetDemoProduct();

            context.Items.Add(item);

            var controller = new ProductAPIController(context);

            var result = controller.Delete(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);

            Assert.AreEqual(item.ID, result.Content.Id);

        }

        Product GetDemoProduct()
        {

            return new Product() { Id = 3, Name = "Demo Product", Price = 5 ,Category ="TestCategory"};

        }

    }

}
