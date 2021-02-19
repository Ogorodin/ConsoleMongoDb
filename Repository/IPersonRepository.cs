using ConsoleMongoDb.Entity;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{
    interface IPersonRepository
    {
        public bool InsertRecord(Person record);
        public List<Person> LoadRecords();
        public Person FindPersonById(string id);
        public List<Person> FindPersonByLastName(string lastName);
        public bool UpdatePerson(string id, string firstName, string lastName);
        public void UpdatePerson(string id, Person updatedPerson);
        public bool DeleteById(string id);
        public long DeleteByLastName(string lastName);
    }
}
