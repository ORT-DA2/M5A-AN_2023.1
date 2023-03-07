using Microsoft.EntityFrameworkCore;
using System.Linq;
using Uyflix.Domain.Entities;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DbSet<Category> categories;
        private readonly DbContext context;
        public CategoriesRepository(DbContext context)
        {
            categories = context.Set<Category>();
            this.context = context;
        }
        public Category GetCategoryById(int id)
        {
            // El método AsNoTracking nos permite concatenar esta llamada con otras acciones
            // sobre el contexto como puede ser un Update. De lo contrario nos daria una excepción.
            return categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
