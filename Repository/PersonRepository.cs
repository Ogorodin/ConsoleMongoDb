using System;
using System.Collections.Generic;
using ConsoleMongoDb.Entity;
using ConsoleMongoDb.Repository;
using MongoDB.Driver;

namespace ConsoleMongoDb.Helpers
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _personCollection;
        public PersonRepository(string database)
        {
            var client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(database);
            _personCollection = db.GetCollection<Person>(Constants.CollectionName_users);
        }

        public bool InsertRecord(Person record)
        {
            try {
                _personCollection.InsertOne(record);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exc caught.");
                return false;
            }
            
        }

        public List<Person> LoadRecords()
        {
            var result = _personCollection.AsQueryable().ToList();
            return result;
        }

        public Person FindPersonById(string id)
        {
            try
            {
                var findFilter = Builders<Person>.Filter.Eq(person => person.Id, Guid.Parse(id));
                Person person = _personCollection.Find(findFilter).FirstOrDefault();
                return person;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Person> FindPersonByLastName(string lastName)
        {
            return _personCollection.Find(person => person.LastName.Contains(lastName)).ToList();
        }

        public bool UpdatePerson(string id, string firstName, string lastName)
        {
            try
            {
                var findFilter = Builders<Person>.Filter.Eq(Constants.PersonID_fieldName, Guid.Parse(id));
                var update = Builders<Person>.Update
                    .Set(Constants.PersonFirstName_fieldName, firstName)
                    .Set(Constants.PersonLastName_fieldName, lastName);
                return _personCollection.UpdateOne(findFilter, update).ModifiedCount > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdatePerson(string id, Person updatedPerson)
        {
            try
            {
                _personCollection.ReplaceOne(p => p.Id == Guid.Parse(id), updatedPerson);
            }
            catch (Exception)
            {
                Console.WriteLine("EXCEPTION THROWN!");
            }
        }

        public bool DeleteById(string id)
        {
            var deleteFilter = Builders<Person>.Filter.Eq(person => person.Id, Guid.Parse(id));
            return _personCollection.DeleteOne(deleteFilter).DeletedCount > 0;
        }

        public long DeleteByLastName(string lastName)
        {
            long count = 0;
            while (_personCollection.DeleteOne(person => person.LastName.Contains(lastName)).DeletedCount > 0)
            {
                count++;
            }
            return count;
        }
    }
}
