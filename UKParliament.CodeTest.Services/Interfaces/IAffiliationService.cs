using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Services.Interfaces
{
    internal interface IAffiliationService
    {
        List<Affiliation> GetAll();
    }
}
