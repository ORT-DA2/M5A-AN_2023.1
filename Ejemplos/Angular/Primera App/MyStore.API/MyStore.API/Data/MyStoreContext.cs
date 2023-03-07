using Microsoft.EntityFrameworkCore;
using MyStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.API.Data
{
    public class MyStoreContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public MyStoreContext(DbContextOptions options) : base(options) { }
    }
}
