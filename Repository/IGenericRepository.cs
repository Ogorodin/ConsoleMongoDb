using ConsoleMongoDb.Entity;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{   
    interface IGenericRepository<T> where T : BaseEntity
    {
        public List<T> LoadAllRecords();
        public bool AddRecord(T record);
        public T FindById(string id);
        public bool UpdateRecord<T>(string id, T updatedRecord) where T : BaseEntity;
        public bool DeleteRecord(string id);
    }
}
