using Bierland.businesslogicInterface;
using Bierland.dataaccessInterface;
using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bierland.businesslogic
{
    public class PubLogic : IPubLogic
    {
        private readonly IRepository<Pub> repository;
        private readonly IBeerLogic beerLogic;
        public PubLogic(IRepository<Pub> repository, IBeerLogic beerLogic)
        {
            this.repository = repository;
            this.beerLogic = beerLogic;
        }
        public Pub Add(Pub pub)
        {
            pub.IsDeleted = false;
            repository.Create(pub);
            repository.Save();
            return pub;
        }

        public void AddBeer(int pubId, int beerId)
        {
            Pub pub = repository.Get(pubId);
            if (pub == null) throw new Exception("Pub does't exist");
            Beer beer = beerLogic.GetById(beerId);
            if (beer == null) throw new Exception("beer does't exist");
            BeerPubs beerPubs = new BeerPubs()
            {
                Beer = beer,
                BeerId = beerId,
                Pub = pub,
                PubId = pubId
            };
            pub.BeerPubs.Add(beerPubs);
            repository.Update(pub);
            repository.Save();
        }

        public void Delete(int id)
        {
            Pub pub = repository.Get(id);
            if (pub == null) throw new Exception("Pub does't exist");
            pub.IsDeleted = true;
            repository.Update(pub);
            repository.Save();
        }

        public IEnumerable<Pub> GetAll()
        {
            return repository.GetAll().Where(x => x.IsDeleted == false);
        }

        public Pub GetById(int id)
        {
            Pub pub = repository.Get(id);
            if (pub.IsDeleted == true) throw new Exception("Pub does't exist");
            else return pub;
        }

        public void Update(Pub newPub)
        {
            Pub pub = repository.Get(newPub.Id);
            if (pub != null && pub.IsDeleted == false)
            {
                pub.Name = newPub.Name;
                pub.Address = newPub.Address;
                repository.Update(pub);
                repository.Save();
            }
            else throw new Exception("Pub does't exist");
        }
    }
}
