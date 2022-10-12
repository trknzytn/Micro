using Micro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Micro.Dal.Concrates.EF
{
    public class MicroMediaContext : DbContext
    {
        public MicroMediaContext(DbContextOptions<MicroMediaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().ToTable("Movies") ;
            modelBuilder.Entity<MovieObject>().ToTable("MovieObjects");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<MovieVote>().ToTable("MovieVotes");            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieObject> MovieObjects { get; set; }
        public virtual DbSet<MovieVote> MovieVotes { get; set; }

    }
}
