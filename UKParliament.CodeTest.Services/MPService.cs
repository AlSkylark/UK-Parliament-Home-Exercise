using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;

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

        public IEnumerable<MP> GetAll(int page)
        {
            //basic offset pagination
            //?page=1 = 10, ?page=2 = 10 * 2, etc.
            int pageLimit = 10;

            return _context.MPs
                .Include(mp => mp.Address)
                .Include(mp => mp.Affiliation)
                .OrderBy(v => v.Name)
                .Skip((page - 1) * pageLimit)
                .Take(pageLimit)
                .ToList();
        }

        public int GetCount()
        {
            return _context.MPs.Count();
        }

        public MP? Update(MP mp)
        {
            _context.MPs.Update(mp);
            return _context.SaveChanges() > 0 ? mp : null;
        }
    }
}
