using backend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Data
{
    public class ProdutoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType()
                .GetProperty("Inclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Inclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Inclusao").IsModified = false;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}