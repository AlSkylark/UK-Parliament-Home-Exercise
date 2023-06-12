using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Services
{
    public class AddressService : IAddressService
    {
        private readonly PersonManagerContext _context;
        public AddressService(PersonManagerContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }
    }
}
