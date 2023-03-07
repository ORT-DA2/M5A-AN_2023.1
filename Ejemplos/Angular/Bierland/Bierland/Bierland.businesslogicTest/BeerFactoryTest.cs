using Bierland.businesslogic;
using Bierland.dataaccessInterface;
using Bierland.domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Bierland.businesslogicTest
{
    [TestClass]
    public class BeerFactoryTest
    {
        [TestMethod]
        public void GetByIdOk()
        {
            var daMock = new Mock<IRepository<BeerFactory>>(MockBehavior.Strict);
            BeerFactoryLogic logic = new BeerFactoryLogic(daMock.Object);
            BeerFactory beerFactory = new BeerFactory()
            {
                Id = 1,
                IsDeleted = false,
                Name = "Prueba",
                Nationality = "Prueba"
            };

            daMock.Setup(x => x.Get(1)).Returns(beerFactory);

            BeerFactory ret = logic.GetById(1);

            daMock.VerifyAll();

            Assert.AreEqual(1, ret.Id);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void GetByIdDeleted()
        {
            var daMock = new Mock<IRepository<BeerFactory>>(MockBehavior.Strict);
            BeerFactoryLogic logic = new BeerFactoryLogic(daMock.Object);
            BeerFactory beerFactory = new BeerFactory()
            {
                Id = 1,
                IsDeleted = true,
                Name = "Prueba",
                Nationality = "Prueba"
            };

            daMock.Setup(x => x.Get(1)).Returns(beerFactory);
            BeerFactory ret = logic.GetById(1);

            daMock.VerifyAll();
        }
    }
}
