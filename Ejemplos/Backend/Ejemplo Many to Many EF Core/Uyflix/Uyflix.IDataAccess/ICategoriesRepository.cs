using System;
using System.Linq;
using Uyflix.Domain.Entities;

namespace Uyflix.IDataAccess
{
    public interface ICategoriesRepository
    {
        Category GetCategoryById(int id);
        void Save();
    }
}
