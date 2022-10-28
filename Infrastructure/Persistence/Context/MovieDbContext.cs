using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options):base(options)
        {

        }
       public DbSet<Actor>Actors { get; set; }
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
