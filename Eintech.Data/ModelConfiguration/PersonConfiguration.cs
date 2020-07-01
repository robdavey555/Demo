using Eintech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Eintech.Data.ModelConfiguration
{
    [ExcludeFromCodeCoverage]
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
               .HasKey(k => k.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(b => b.Name); //We'll be searching against this column so index it

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.People)
                .HasForeignKey(f => f.GroupId);
        }
    }
}