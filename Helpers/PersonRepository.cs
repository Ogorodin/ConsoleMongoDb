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
        private readonly IMongoCollection<Person> _collection;

        public PersonRepository(string database)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(database);
            _collection = _db.GetCollection<Person>(Constants.CollectionName_users);
        }

        public void InsertRecord<T>(string collectionName, Person record)
        {
            _collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string collectionName)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var result = collection.AsQueryable().ToList();
            return result;
        }

        //public List<Person> FindPersonByFullName(string collectionName, string firstName, string lastName)
        //{
        //   // return _collection.Find(person => person.FirstName.Contains(firstName) && person.LastName.Contains(lastName)).ToList();
        //}

        public List<Person> FindPersonByLastName(string collectionName, string lastName)
        {
            return _collection.Find(person => person.LastName.Contains(lastName)).ToList();
        }

        public void UpdatePerson()
        {
            /*
                MyType myObject; // passed in 
                var filter = Builders<MyType>.Filter.Eq(s => s.Id, id);
                var result = await collection.ReplaceOneAsync(filter, myObject)
            */
        }

        public DeleteResult DeleteById(string collectionName, string id)
        {
            var deleteFilter = Builders<Person>.Filter.Eq(person => person.Id, Guid.Parse(id));
            return _collection.DeleteOne(deleteFilter);
        }

        public long DeleteByLastName(string collectionName, string lastName)
        {
            long count = 0;
            while (_collection.DeleteOne(person => person.LastName.Contains(lastName)).DeletedCount > 0)
            {
                count++;
            }
            return count;

        }
    }
}
