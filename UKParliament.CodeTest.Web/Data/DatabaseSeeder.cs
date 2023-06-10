using Bogus;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Web.Data
{
    public class DatabaseSeeder
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PersonManagerContext>();
                context.Database.EnsureCreated();

                //affiliation
                var affiliations = new List<Affiliation>()
                {
                    new Affiliation()
                    {
                        AffiliationId = 1,
                        Name = "Labour"
                    },
                    new Affiliation()
                    {
                        AffiliationId = 2,
                        Name = "Conservative"
                    },
                    new Affiliation()
                    {
                        AffiliationId = 3,
                        Name="Independent"
                    },
                    new Affiliation()
                    {
                        AffiliationId = 4,
                        Name = "Liberal Democrat"
                    }
                };

                context.Affiliations.AddRange(affiliations);

                //addresses
                Address addressMaker() => new Faker<Address>(locale: "en_GB")
                    .RuleFor(v => v.AddressId, f => f.UniqueIndex)
                    .RuleFor(v => v.Address1, f => f.Address.StreetAddress())
                    .RuleFor(v => v.Address2, f => f.Address.SecondaryAddress())
                    .RuleFor(v => v.Town, f => f.Address.City())
                    .RuleFor(v => v.County, f => f.Address.County())
                    .RuleFor(v => v.Postcode, f => f.Address.ZipCode());

                //mps
                int MPIds = 1;
                var fakeMPs = new Faker<MP>(locale: "en_GB")
                    .RuleFor(v => v.PersonId, f => MPIds++)
                    .RuleFor(v => v.Address, f => addressMaker())
                    .RuleFor(v => v.Affiliation, f => f.PickRandom(affiliations))
                    .RuleFor(v => v.DOB, f => f.Date.Between(new DateTime(1930, 1, 1), new DateTime(1960, 1, 1)))
                    .RuleFor(v => v.Name, f => f.Name.FullName())
                    .Generate(50);

                context.MPs.AddRange(fakeMPs);
                context.SaveChanges();
            }
        }
    }
}
