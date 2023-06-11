using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data
{
    public class PersonManagerContext : DbContext
    {
        public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MP>().HasBaseType<Person>();
            modelBuilder.Entity<MP>().HasOne(v => v.Address);
            modelBuilder.Entity<MP>().HasOne(v => v.Affiliation);
            modelBuilder.Entity<MP>().Property(v => v.DateCreated)
                .HasValueGenerator<CurrentDateTimeValueGenerator>().ValueGeneratedOnAdd();
            modelBuilder.Entity<MP>().Property(v => v.DateModified)
                .HasValueGenerator<CurrentDateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MP> MPs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }

    }

    /// <summary>
    /// Can't use .HasDefaultValueSql("GetDate()") so I made my own!
    /// </summary>
    public class CurrentDateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override DateTime Next(EntityEntry entry)
        {
            return DateTime.Now;
        }

        public override bool GeneratesTemporaryValues => false;
    }
}