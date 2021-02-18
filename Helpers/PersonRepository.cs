using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMongoDb.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

using ConsoleMongoDb.Helpers;

namespace ConsoleMongoDb.Helpers
{
    public class PersonRepository
    {

        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<Person> _personCollection;

        public PersonRepository(string database)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(database);
            _personCollection = _db.GetCollection<Person>(Constants.CollectionName_users);
        }

        public void InsertRecord(Person record)
        {
            _personCollection.InsertOne(record);
        }

        public List<Person> LoadRecords(string collectionName)
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

        public UpdateResult UpdatePerson(string id, string firstName, string lastName)
        {
            try
            {
                var findFilter = Builders<Person>.Filter.Eq(Constants.PersonID_fieldName, Guid.Parse(id));
                var update = Builders<Person>.Update.Set(Constants.PersonFirstName_fieldName, firstName)
                    .Set(Constants.PersonLastName_fieldName, lastName);
                var we = _personCollection.UpdateOne(findFilter, update);
                return we;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DeleteResult DeleteById(string id)
        {
            var deleteFilter = Builders<Person>.Filter.Eq(person => person.Id, Guid.Parse(id));
            return _personCollection.DeleteOne(deleteFilter);
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
