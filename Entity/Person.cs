using System;

using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongoDb.Entity
{
    public class Person : BaseEntity
    {
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nFirst name: {FirstName}\nLastName: {LastName}";
        }
    }
}
