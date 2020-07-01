using Eintech.Data.Extensions;
using Eintech.Data.ModelConfiguration;
using Eintech.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Eintech.Data
{
    [ExcludeFromCodeCoverage]
    public class EintechContext : DbContext
    {
        public EintechContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set database config using FluentAPI
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            //always seed data for this demo
            modelBuilder.Seed();
        }

        public override int SaveChanges()
        {
            //get entities that have been added where _Base class is inherited
            var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is _Base && (e.State == EntityState.Added));

            //loop added enities
            foreach (var entityEntry in entries)
            {
                ((_Base)entityEntry.Entity).CreatedOn = DateTime.Now; //automatically ensure that date is set
            }

           return base.SaveChanges();
        }
    }
}