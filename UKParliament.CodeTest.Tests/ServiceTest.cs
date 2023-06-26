using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.Data;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class ServiceTest : IDisposable
    {
        private readonly PersonManagerContext context;
        private readonly MPService service;
        private readonly AffiliationService affiService;

        public ServiceTest()
        {
            var options = new DbContextOptionsBuilder<PersonManagerContext>()
                .UseInMemoryDatabase("TestDb").UseLazyLoadingProxies().Options;
            context = new PersonManagerContext(options);
            if (!context.MPs.Any()) DatabaseSeeder.Seed(context);
            service = new MPService(context);
            affiService = new AffiliationService(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Fact]
        public void I_Get_Something_When_Getting_All()
        {
            Assert.NotEmpty(service.GetAll(1));
        }

        [Fact]
        //Used to understand issues with lazy loading
        public void Affiliation_and_Address_are_not_null()
        {
            var random = new Random();
            int rnd = random.Next(1, 10);
            var mp = service.GetAll(1).ElementAt(rnd);

            Assert.NotNull(mp.Affiliation);
            Assert.NotNull(mp.Address);
        }

        [Fact]
        public void Pagination_Spits_10()
        {
            var mps = service.GetAll(1);

            int expected = 10;
            int count = mps.Count();

            Assert.Equal(expected, count);
        }

        [Fact]
        public void Pagination_Can_Change_Pages()
        {
            var mps = service.GetAll(1);
            var mp = mps.First();

            var mps2 = service.GetAll(2);
            var mp2 = mps2.First();

            Assert.NotEqual(mp, mp2);
        }

        [Fact]
        public void Pagination_Returns_Nothing_If_More_Than_Final_Page()
        {
            //the seeder creates 55 records, so there shouldn't be more than 6 pages
            var mps = service.GetAll(9);

            Assert.Empty(mps);
        }

        [Fact]
        public void Pagination_Last_Page_Should_Have_5()
        {
            var mps = service.GetAll(6);

            var expected = 5;
            var count = mps.Count();

            Assert.Equal(expected, count);
        }

        [Fact]
        public void Count_Should_Be()
        {
            var count = service.GetCount();

            var expected = 55;

            Assert.Equal(expected, count);
        }

        [Fact]
        public void Count_Increases_When_Adding()
        {
            var count = service.GetCount();

            var expected = 55;

            var mpToCreate = DatabaseSeeder.CreateFakeMP();
            service.Create(mpToCreate);

            var secondCount = service.GetCount();
            Assert.Equal(expected, count);
            Assert.Equal(expected + 1, secondCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(39)]
        public void Get_Should_Return_An_MP(int id)
        {
            var mp = service.Get(id);

            Assert.NotNull(mp);
        }

        [Fact]
        public void Get_Should_Fail_if_Id_Doesnt_Exist()
        {
            var mp = service.Get(10000);

            Assert.Null(mp);
        }

        [Fact]
        public void Create_An_MP()
        {
            var mpToCreate = DatabaseSeeder.CreateFakeMP();
            Assert.True(mpToCreate.PersonId == 0);

            var mpReturned = service.Create(mpToCreate);
            Assert.Equal(mpToCreate, mpReturned);


            var mpInDb = service.Get(mpReturned.PersonId);
            Assert.Equal(mpToCreate, mpInDb);
        }

        [Fact]
        public void Created_Should_Have_Dates()
        {
            var mpToCreate = DatabaseSeeder.CreateFakeMP();
            var mpReturned = service.Create(mpToCreate);

            Assert.Equal(mpReturned.DateCreated.Date, DateTime.Now.Date);
            Assert.Equal(mpReturned.DateModified.Date, DateTime.Now.Date);
        }

        [Fact]
        public void Update_Should_Change_MP()
        {
            var mp = service.Get(1);

            var ogName = mp.Name;

            mp.Name = "Test Name";

            var modMp = service.Update(mp);

            Assert.NotNull(modMp);
            Assert.NotEqual(ogName, modMp.Name);
            Assert.Equal("Test Name", modMp.Name);
        }

        [Fact]
        public void Update_Should_Update_DateModified()
        {
            var mp = service.Get(1);
            var ogName = mp.Name;
            var ogDate = mp.DateModified;

            mp.Name = "Modified Name";

            Thread.Sleep(1000);

            var modMp = service.Update(mp);

            Assert.NotNull(modMp);
            Assert.NotEqual(ogName, modMp.Name);
            Assert.NotEqual(ogDate, modMp.DateModified);
        }

        [Fact]
        public void Delete_Should_Delete_MP()
        {
            var mpToCreate = DatabaseSeeder.CreateFakeMP();
            var mpCreated = service.Create(mpToCreate);

            bool deleted = service.Delete(mpCreated.PersonId);
            var retrieve = service.Get(mpCreated.PersonId);

            Assert.True(deleted);
            Assert.Null(retrieve);
        }


        [Fact]
        public void I_Should_Get_All_Affiliations()
        {
            var affis = affiService.GetAll();

            int expected = 4;
            var count = affis.Count;

            Assert.Equal(expected, count);
        }
    }
}
