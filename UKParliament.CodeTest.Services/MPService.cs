using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    public class MPService : IPersonService<MP>
    {
        private readonly PersonManagerContext _context;
        public MPService(PersonManagerContext context)
        {
            _context = context;
        }

        public MP Create(MP mp)
        {
            _context.MPs.Add(mp);
            _context.SaveChanges();
            return mp;
        }

        public bool Delete(int id)
        {
            var mp = _context.MPs.Where(mp => mp.PersonId == id).FirstOrDefault();
            if (mp is null) return false;

            _context.MPs.Remove(mp);
            return (_context.SaveChanges() == 1);
        }

        public MP? Get(int id)
        {
            var mp = _context.MPs.Where(mp => mp.PersonId == id).FirstOrDefault();
            return mp;
        }

        public List<MP> GetAll(bool expanded)
        {
            if (expanded) return _context.MPs.Include(mp => mp.Address).Include(mp => mp.Affiliation).ToList();
            return _context.MPs.ToList();
        }

        public MP? Update(MP mp)
        {
            _context.MPs.Update(mp);
            return _context.SaveChanges() > 0 ? mp : null;
        }
    }
}
