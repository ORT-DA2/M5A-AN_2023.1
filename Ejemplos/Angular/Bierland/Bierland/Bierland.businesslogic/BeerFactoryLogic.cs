using Bierland.businesslogicInterface;
using Bierland.dataaccessInterface;
using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bierland.businesslogic
{
    public class BeerFactoryLogic : IBeerFactoryLogic
    {
        private readonly IRepository<BeerFactory> repository;
        public BeerFactoryLogic(IRepository<BeerFactory> repository)
        {
            this.repository = repository;
        }

        public BeerFactory Add(BeerFactory beerFactory)
        {
            beerFactory.IsDeleted = false;
            repository.Create(beerFactory);
            repository.Save();
            return beerFactory;
        }

        public void Delete(int id)
        {
            BeerFactory beerFactory = repository.Get(id);
            if (beerFactory == null) throw new Exception("BeerFactory does't exist");
            beerFactory.IsDeleted = true;
            repository.Update(beerFactory);
            repository.Save();
        }

        public IEnumerable<BeerFactory> GetAll()
        {
            return repository.GetAll().Where(x => x.IsDeleted == false);
        }

        public BeerFactory GetById(int id)
        {
            BeerFactory beerFactory = repository.Get(id);
            if (beerFactory != null && beerFactory.IsDeleted == false) return beerFactory;
            else throw new Exception("BeerFactory does't exist"); ;
        }

        public void Update(BeerFactory newBeerFactory)
        {
            BeerFactory beerFactory = repository.Get(newBeerFactory.Id);
            if (beerFactory != null && beerFactory.IsDeleted == false)
            {
                repository.Update(newBeerFactory);
                repository.Save();
            }
            else throw new Exception("BeerFactory does't exist");
        }
    }
}
