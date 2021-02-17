using System;

using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongoDb.Entity
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }

        public string toString()
        {
            return $"ID: {Id}\nFirst name: {FirstName}\nLastName: {LastName}";
        }
    }
}
