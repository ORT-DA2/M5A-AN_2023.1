using Microsoft.EntityFrameworkCore;
using MyStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace MyStore.API.Data
{
    public class ProductManager
    {
        private readonly DbSet<Product> products;
        private readonly DbContext context;
        public ProductManager(DbContext context)
        {
            this.products = context.Set<Product>();
            this.context = context;
        }
        public IList<Product> GetProducts()
        {
            return this.products.ToList();
        }
        public void CreateProduct(Product product)
        {
            this.products.Add(product);
            this.context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            this.products.Remove(new Product() { Id = id });
            this.context.SaveChanges();
        }
        public Product GetProduct(int id)
        {
            return this.products.Find(id);
        }
    }
}
