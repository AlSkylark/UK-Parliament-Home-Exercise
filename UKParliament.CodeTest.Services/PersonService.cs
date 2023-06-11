using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Services
{
    public class PersonService : IPersonService<Person>
    {
        //Not going to use this Service since I'm going to focus on the MPs, but the idea 
        //of using the same interface is that this can potentially be used for other types of Person
        public Person Create()
        {
            throw new NotImplementedException();
        }

        public Person? Create(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DoSomething()
        {
            return;
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll(bool s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public Person Update(int id)
        {
            throw new NotImplementedException();
        }

        public Person? Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}