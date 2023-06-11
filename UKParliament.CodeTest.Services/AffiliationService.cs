using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Services
{
    public class AffiliationService : IAffiliationService
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
