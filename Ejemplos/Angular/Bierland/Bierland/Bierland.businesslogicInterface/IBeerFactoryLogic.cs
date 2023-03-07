using System;
using System.Collections.Generic;
using Bierland.domain;

namespace Bierland.businesslogicInterface
{
    public interface IBeerFactoryLogic
    {
        IEnumerable<BeerFactory> GetAll();
        BeerFactory Add(BeerFactory beerFactory);
        void Update(BeerFactory beerFactory);
        void Delete(int id);
        BeerFactory GetById(int id);
    }
}
