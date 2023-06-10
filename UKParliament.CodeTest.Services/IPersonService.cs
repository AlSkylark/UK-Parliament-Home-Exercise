namespace UKParliament.CodeTest.Services
{
    public interface IPersonService<T>
    {
        IEnumerable<T> GetAll(bool expanded);
        T? Get(int id);
        T? Create(T person);
        T? Update(T person);
        bool Delete(int id);
    }
}