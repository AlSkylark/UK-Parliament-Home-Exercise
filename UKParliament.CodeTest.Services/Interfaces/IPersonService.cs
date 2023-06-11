namespace UKParliament.CodeTest.Services.Interfaces
{
    public interface IPersonService<T>
    {
        IEnumerable<T> GetAll(int page);
        int GetCount();
        T? Get(int id);
        T? Create(T person);
        T? Update(T person);
        bool Delete(int id);
    }
}