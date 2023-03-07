using System;
using System.Collections.Generic;
using Bierland.domain;

namespace Bierland.businesslogicInterface
{
    public interface IBeerLogic
    {
        IEnumerable<Beer> GetAll();
        Beer Add(Beer beer, int beerFactoryId);
        void Update(Beer beer);
        void Delete(int id);
        Beer GetById(int id);
    }
}
