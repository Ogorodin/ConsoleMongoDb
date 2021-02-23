using ConsoleMongoDb.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{
    class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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
        public bool AddRecord(T record)
        {
            try
            {
                _genericCollection.InsertOne(record);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public T FindById(string id)
        {
            try
            {
                return _genericCollection.Find(record => record.Id == Guid.Parse(id)).FirstOrDefault();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught in Console.MongoDb.Repository.GenericRepository.");
                return null;
            }
        }
        public bool UpdateRecord<T>(string id, T updatedRecord) where T : BaseEntity
        {
            //  _genericCollection.ReplaceOne(record => record.Id == Guid.Parse(id), updatedRecord);

            return true;
        }
        public bool DeleteRecord(string id)
        {
            try
            {
                return _genericCollection.DeleteOne(record => record.Id == Guid.Parse(id)).DeletedCount > 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught in Console.MongoDb.Repository.GenericRepository.");
                return false;
            }

        }






    }


}
