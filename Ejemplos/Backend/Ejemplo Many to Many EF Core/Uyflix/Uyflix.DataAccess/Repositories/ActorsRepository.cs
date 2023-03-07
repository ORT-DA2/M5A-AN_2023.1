using Microsoft.EntityFrameworkCore;
using System.Linq;
using Uyflix.Domain.Entities;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess.Repositories
{
    public class ActorsRepository : IActorsRepository
    {
        private readonly DbSet<Actor> actors;
        private readonly DbContext context;
        public ActorsRepository(DbContext context)
        {
            actors = context.Set<Actor>();
            this.context = context;
        }
        public Actor GetActorById(int id)
        {
            // El método AsNoTracking nos permite concatenar esta llamada con otras acciones
            // sobre el contexto como puede ser un Update. De lo contrario nos daria una excepción.
            return actors.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
