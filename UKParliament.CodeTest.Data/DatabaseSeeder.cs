using Bogus;
using System.Drawing;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Web.Data
{
    public class DatabaseSeeder
    {
        private static readonly List<Affiliation> Affiliations = new()
                    {
                        new Affiliation()
                        {
                            Name = "Labour",
                            Color = ColorTranslator.FromHtml("#ff0000")
                        },
                        new Affiliation()
                        {
                            Name = "Conservative",
                            Color = ColorTranslator.FromHtml("#0000ff")
                        },
                        new Affiliation()
                        {
                            Name = "Independent",
                             Color = ColorTranslator.FromHtml("#C0C0C0")
                        },
                        new Affiliation()
                        {
                            Name = "Liberal Democrat",
                            Color = ColorTranslator.FromHtml("#f8a428")
                        }
                    };

        /// <summary>
        /// Seeds the provided context with fake data.
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(PersonManagerContext context)
        {
            //using var scope = builder.ApplicationServices.CreateScope();
            //var context = scope.ServiceProvider.GetService<PersonManagerContext>();
            context.Database.EnsureCreated();

            context.Affiliations.AddRange(Affiliations);

            //mps
            var fakeMPs = CreateFakeMP(55);

            context.MPs.AddRange(fakeMPs);
            context.SaveChanges();
        }

        /// <summary>
        /// Creates a list of MPs given an amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static List<MP> CreateFakeMP(int amount)
        {
            return new Faker<MP>(locale: "en_GB")
                .RuleFor(v => v.Address, f => CreateFakeAddress())
                .RuleFor(v => v.Affiliation, f => f.PickRandom(Affiliations))
                .RuleFor(v => v.DOB, f => f.Date.Between(new DateTime(1930, 1, 1), new DateTime(1960, 1, 1)))
                .RuleFor(v => v.Name, f => f.Name.FullName()).Generate(amount);
        }

        /// <summary>
        /// Creates one random MP.
        /// </summary>
        /// <returns></returns>
        public static MP CreateFakeMP()
        {
            return new Faker<MP>(locale: "en_GB")
                .RuleFor(v => v.Address, f => CreateFakeAddress())
                .RuleFor(v => v.Affiliation, f => f.PickRandom(Affiliations))
                .RuleFor(v => v.DOB, f => f.Date.Between(new DateTime(1930, 1, 1), new DateTime(1960, 1, 1)))
                .RuleFor(v => v.Name, f => f.Name.FullName());
        }

        /// <summary>
        /// Creates a fake address.
        /// </summary>
        /// <returns></returns>
        public static Address CreateFakeAddress()
        {
            return new Faker<Address>(locale: "en_GB")
                .RuleFor(v => v.Address1, f => f.Address.StreetAddress())
                .RuleFor(v => v.Address2, f => f.Address.SecondaryAddress())
                .RuleFor(v => v.Town, f => f.Address.City())
                .RuleFor(v => v.County, f => f.Address.County())
                .RuleFor(v => v.Postcode, f => f.Address.ZipCode());
        }
    }
}
