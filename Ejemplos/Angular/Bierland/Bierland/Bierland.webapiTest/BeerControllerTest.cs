using Bierland.businesslogicInterface;
using Bierland.domain;
using Bierland.webapi.Controllers;
using Bierland.webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Bierland.webapiTest
{
    [TestClass]
    public class BeerControllerTest
    {
        [TestMethod]
        public void PostBeerOk()
        {
            var logicMock = new Mock<IBeerLogic>(MockBehavior.Strict);
            BeerController controller = new BeerController(logicMock.Object);
            BeerModel beerModel = new BeerModel()
            {
                BeerFactoryId = 1,
                Description = "Prueba",
                Name = "Prueba",
                Qualification = 1
            };

            logicMock.Setup(x => x.Add(It.IsAny<Beer>(), 1)).Returns(It.IsAny<Beer>());

            var result = controller.Post(beerModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Beer;

            logicMock.VerifyAll();
        }

        [TestMethod]
        public void PutBeerOk()
        {
            var logicMock = new Mock<IBeerLogic>(MockBehavior.Strict);
            BeerController controller = new BeerController(logicMock.Object);
            BeerModel beerModel = new BeerModel()
            {
                BeerFactoryId = 1,
                Description = "Prueba",
                Name = "Prueba",
                Qualification = 1
            };

            logicMock.Setup(x => x.Update(It.IsAny<Beer>()));

            var result = controller.Put(1, beerModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        [TestMethod]
        public void PutBeerNotExist()
        {
            var logicMock = new Mock<IBeerLogic>(MockBehavior.Strict);
            BeerController controller = new BeerController(logicMock.Object);
            BeerModel beerModel = new BeerModel()
            {
                BeerFactoryId = 1,
                Description = "Prueba",
                Name = "Prueba",
                Qualification = 1
            };

            logicMock.Setup(x => x.Update(It.IsAny<Beer>())).Throws(new Exception());

            var result = controller.Put(1, beerModel);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }
    }
}
