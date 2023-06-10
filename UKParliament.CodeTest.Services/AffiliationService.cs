using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    internal class AffiliationService : IAffiliationService
    {
        private readonly PersonManagerContext _context;
        public AffiliationService(PersonManagerContext context)
        {
            _context = context;
        }

        public List<Affiliation> GetAll()
        {
            return _context.Affiliations.ToList();
        }
    }
}
