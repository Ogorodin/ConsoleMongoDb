using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMongoDb.Repository
{
   
    interface IGenericRepository<T>
    {
        public List<T> LoadAllRecords();
        public T FindById(string id);
        public bool UpdateRecord(string id, T type);
        public bool DeleteRecord(string id);
    }
}
