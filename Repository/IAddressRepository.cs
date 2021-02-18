using ConsoleMongoDb.Entity;
using System.Collections.Generic;

namespace ConsoleMongoDb.Repository
{
    interface IAddressRepository
    {
        public bool AddAddress(Address address);
        public List<Address> LoadAllAddressess();
        public Address FindAddressByID(string id);
        public List<Address> FindAddressByStreetName(string streetName);
        public List<Address> FindAddressByCityName(string cityName);
        public bool DeleteAddressById(string id);
        public bool UpdateAddressById(string id);
    }
}
