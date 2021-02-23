using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMongoDb.Entity
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
