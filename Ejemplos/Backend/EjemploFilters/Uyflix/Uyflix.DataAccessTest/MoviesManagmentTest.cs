using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Uyflix.DataAccess;
using Uyflix.Domain.Entities;
using System.Linq;

namespace Uyflix.DataAccessTest
{
    [TestClass]
    public class MoviesManagmentTest
    {
        private DbContext context;
        private Movie iceAge;
        private MoviesManagment managment;
        [TestInitialize]
        public void InitTest()
        {
            iceAge = new Movie()
            {
                Category = "Animada",
                Country = "Estados Unidos",
                Director = "Chris Wedge y Carlos Saldanha",
                Name = "La Era de Hielo",
                Rating = 5,
                Year = 2002
            };
        }
        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<UyflixContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new UyflixContext(options);

            context.Set<Movie>().Add(iceAge);
            context.SaveChanges();

            managment = new MoviesManagment(context);
        }
        [TestMethod]
        public void Get()
        {
            CreateDataBase("GetTestDB");
            int size = managment.GetMovies().ToList().Count;
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void Insert()
        {
            Movie theRing = new Movie()
            {
                Id = 2,
                Category = "Terror",
                Country = "Estados Unidos",
                Director = "Gore Verbinski",
                Name = "El Aro",
                Rating = 4,
                Year = 2002
            };
            CreateDataBase("InsertTestDB");
            managment.InsertMovie(theRing);
            managment.Save();
            int size = managment.GetMovies().ToList().Count;
            Assert.AreEqual(2, size);
        }

        [TestMethod]
        public void Delete()
        {
            CreateDataBase("DeleteTestDB");
            managment.DeleteMovie(iceAge);
            managment.Save();
            int size = managment.GetMovies().ToList().Count;
            Assert.AreEqual(0, size);
        }

        [TestMethod]
        public void Update()
        {
            CreateDataBase("UpdateTestDB");
            int size = managment.GetMovies().ToList().Count;
            managment.Save();
            Assert.AreEqual(1, size);
        }
    }
}
