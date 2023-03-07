using System;
using System.Collections.Generic;
using Bierland.domain;

namespace Bierland.businesslogicInterface
{
    public interface IPubLogic
    {
        IEnumerable<Pub> GetAll();
        Pub Add(Pub pub);
        void Update(Pub pub);
        void Delete(int id);
        Pub GetById(int id);
        void AddBeer(int pubId, int beerId);
    }
}
