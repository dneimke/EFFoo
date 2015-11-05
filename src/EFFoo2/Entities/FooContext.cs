using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFFoo2.Entities
{
    public class FooContext : DbContext
    {

        public DbSet<Customer> Foo { get; set; }
        public DbSet<Supplier> Foo2 { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
