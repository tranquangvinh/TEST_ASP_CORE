using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class TestAPIContext: DbContext
    {
        public DbSet<Actuals> Actuals { get; set; }
        public DbSet<Estimates> Estimates { get; set; }

        public TestAPIContext(DbContextOptions<TestAPIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //table names :  Actuals
            modelBuilder.Entity<Actuals>().ToTable("Actuals");
            modelBuilder.Entity<Actuals>(entity =>
            {
                entity.HasKey(e => e.State);
            });

            //table names :  Estimates
            modelBuilder.Entity<Estimates>().ToTable("Estimates");
            modelBuilder.Entity<Estimates>(entity =>
            {
                entity.HasKey(e => new {e.State, e.Districts});
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
