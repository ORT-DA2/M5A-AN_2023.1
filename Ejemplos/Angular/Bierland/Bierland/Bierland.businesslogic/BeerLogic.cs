using Bierland.businesslogicInterface;
using Bierland.dataaccessInterface;
using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bierland.businesslogic
{
    public class BeerLogic : IBeerLogic
    {
        private readonly IRepository<Beer> repository;
        private readonly IBeerFactoryLogic beerFactoryLogic;
        public BeerLogic(IRepository<Beer> repository, IBeerFactoryLogic beerFactoryLogic)
        {
            this.repository = repository;
            this.beerFactoryLogic = beerFactoryLogic;
        }
        public Beer Add(Beer beer, int beerFactoryId)
        {
            BeerFactory beerFactory = beerFactoryLogic.GetById(beerFactoryId);
            beer.IsDeleted = false;
            beerFactory.Beers.Add(beer);
            beerFactoryLogic.Update(beerFactory);
            return beer;
        }

        public void Delete(int id)
        {
            Beer beer = repository.Get(id);
            if (beer == null) throw new Exception("Beer does't exist");
            beer.IsDeleted = true;
            repository.Update(beer);
            repository.Save();
        }

        public IEnumerable<Beer> GetAll()
        {
            return repository.GetAll().Where(x => x.IsDeleted == false);
        }

        public Beer GetById(int id)
        {
            Beer beer = repository.Get(id);
            if (beer.IsDeleted == true) throw new Exception("Beer does't exist");
            else return beer;
        }

        public void Update(Beer newBeer)
        {
            Beer beer = repository.Get(newBeer.Id);
            if (beer != null && beer.IsDeleted == false)
            {
                repository.Update(newBeer);
                repository.Save();
            }
            else throw new Exception("Beer does't exist");
        }
    }
}
