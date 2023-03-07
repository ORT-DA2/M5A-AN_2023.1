using System;
using System.Linq;
using Uyflix.Domain.Entities;

namespace Uyflix.IDataAccess
{
    public interface IActorsRepository
    {
        Actor GetActorById(int id);
        void Save();
    }
}
