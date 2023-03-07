using Bierland.dataaccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Bierland.dataaccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> DbSet;
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.DbSet = context.Set<T>();
            this.context = context;
        }
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            //DbSet.Update(entity);
            //context.Entry(entity).State = EntityState.Modified;
            //context.Set<T>().Update(entity);
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
