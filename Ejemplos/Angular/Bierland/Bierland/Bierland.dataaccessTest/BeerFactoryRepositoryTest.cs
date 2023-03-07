using Bierland.dataaccess;
using Bierland.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Bierland.dataaccessTest
{
    [TestClass]
    public class BeerFactoryRepositoryTest
    {
        [TestMethod]
        public void CreateBeerFactoryOk()
        {
            var options = new DbContextOptionsBuilder<BierlandContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new BierlandContext(options))
            {
                var repository = new Repository<BeerFactory>(context);
                BeerFactory beerFactory = new BeerFactory()
                {
                    IsDeleted = false,
                    Name = "Prueba",
                    Nationality = "Prueba",
                };
                repository.Create(beerFactory);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Name);
                context.Set<BeerFactory>().Remove(beerFactory);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void GetBeerFactories()
        {
            var options = new DbContextOptionsBuilder<BierlandContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new BierlandContext(options))
            {
                var repository = new Repository<BeerFactory>(context);
                BeerFactory beerFactory = new BeerFactory()
                {
                    IsDeleted = false,
                    Name = "Prueba",
                    Nationality = "Prueba",
                };
                BeerFactory beerFactory2 = new BeerFactory()
                {
                    IsDeleted = false,
                    Name = "Prueba2",
                    Nationality = "Prueba2",
                };
                context.Set<BeerFactory>().Add(beerFactory);
                context.Set<BeerFactory>().Add(beerFactory2);
                context.SaveChanges();

                IEnumerable<BeerFactory> beerFactories = repository.GetAll();
                Assert.AreEqual(2, beerFactories.Count());
            }
        }
    }
}
