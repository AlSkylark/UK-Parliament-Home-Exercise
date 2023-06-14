using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Services.Interfaces
{
    public interface IPersonService<T>
    {
        IEnumerable<T> GetAll(int page);
        Tuple<IEnumerable<MP>, int> GetSpecificPage(int id);
        int GetCount();
        T? Get(int id);
        T? Create(T person);
        T? Update(T person);
        bool Delete(int id);
    }
}