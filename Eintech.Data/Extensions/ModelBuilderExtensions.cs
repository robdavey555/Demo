using Eintech.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Eintech.Data.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Fakers.Init();

            modelBuilder.Entity<Group>(b =>
            {
                b.HasData(Fakers.Groups);
            });

            modelBuilder.Entity<Person>(b =>
            {
                b.HasData(Fakers.People);
            });
        }
    }
}