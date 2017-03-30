using Finances.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Finances.DAO
{
    public class FinancesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasRequired(m => m.user);
            modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Entity<User>().Property(p => p.name).HasColumnType("character varying");
            //modelBuilder.Properties<string>().Configure(p => p.HasColumnType("character"));

        }
    }
}