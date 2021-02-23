using ConsoleMongoDb.Entity;
using ConsoleMongoDb.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{
    class AddressRepository : IAddressRepository
    {
        private readonly IMongoCollection<Address> _addressCollection;

        public AddressRepository(string database)
        {
            var client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(database);
            _addressCollection = db.GetCollection<Address>(Constants.CollectionName_address);
        }

        public List<Address> LoadAllAddressess()
        {
            try
            {
                return _addressCollection.AsQueryable().ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught.");
                return null;
            }
        }

        public bool AddAddress(Address address)
        {
            try
            {
                _addressCollection.InsertOne(address);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception cought.");
                return false;
            }
        }

        public Address FindAddressByID(string id)
        {
            try
            {
           //     var findFilter = Builders<Address>.Filter.Eq(address => address.Id, Guid.Parse(id));
                return _addressCollection.Find(address => address.Id == Guid.Parse(id)).FirstOrDefault();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught.");
                return null;
            }
        }

        public List<Address> FindAddressByCityName(string cityName)
        {
            try
            {
                return _addressCollection.Find(address => address.City.Contains(cityName)).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Exc caught.");
                return null;
            }
        }

        public List<Address> FindAddressByStreetName(string streetName)
        {
            try
            {
                return _addressCollection.Find(address => address.Street.Contains(streetName)).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Exc caught.");
                return null;
            }
        }

        public bool UpdateAddressById(string id, Address updatedAddress)
        {
            var filter = Builders<Address>.Filter.Eq(Constants.AddressID_fieldName, Guid.Parse(id));
            var update = Builders<Address>.Update
                .Set(Constants.AddressStreet_fieldName, updatedAddress.Street)
                .Set(Constants.AddressNumber_fieldName, updatedAddress.Number)
                .Set(Constants.AddressCity_fieldName, updatedAddress.City);
            return _addressCollection.UpdateOne(filter, update).ModifiedCount > 0;
        }

        public bool DeleteAddressById(string id)
        {
            try
            {
                var deleteFilter = Builders<Address>.Filter.Eq(Constants.AddressID_fieldName, Guid.Parse(id));
                return _addressCollection.DeleteOne(deleteFilter).DeletedCount > 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught.");
                return false;
            }
        }
    }
}
