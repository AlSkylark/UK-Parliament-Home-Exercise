using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data
{
    public class PersonManagerContext : DbContext
    {
        public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MP>().HasOne(v => v.Address);
            modelBuilder.Entity<MP>().HasOne(v => v.Affiliation);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MP> MPs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }


    }
}