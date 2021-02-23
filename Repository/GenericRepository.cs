using ConsoleMongoDb.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{
    class GenericRepository<T> : IGenericRepository<T>
    {
        private IMongoCollection<T> _genericCollection;

        public GenericRepository(string database, string collectionName)
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(database);
            _genericCollection = db.GetCollection<T>(collectionName);
        }

        public List<T> LoadAllRecords()
        {
            try
            {
                return _genericCollection.AsQueryable().ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught in ConsoleMongoDb.Repository.GenericRepository.");
                return null;
            }
        }
        public T FindById(string id)
        {
          
            return default(T);
        }
        public bool UpdateRecord(string id, T type)
        {
            return true;
        }
        public bool DeleteRecord(string id)
        {
            throw new NotImplementedException();
        }






    }


}
