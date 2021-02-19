using System;
using System.Collections.Generic;
using ConsoleMongoDb.Entity;
using ConsoleMongoDb.Helpers;
using ConsoleMongoDb.Repository;
using Printer;

namespace ConsoleMongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            //   IPersonRepository repository = new PersonRepository(Constants.DatabaseName);
            //  GUI gui = new GUI(repository);
            // gui.LoadMenu();

            Console.WriteLine("Press any key to start.");
            Console.ReadLine();

            //   IPersonRepository personRepository = new PersonRepository(Constants.DatabaseName);
            IAddressRepository addressRepository = new AddressRepository(Constants.DatabaseName);
            // INSERT ADDRESS
            /*         
           addressRepository.AddAddress(new Entity.Address { 
               Street = "ul. Smokava",
               Number = 222,
               City = "Titel"});
           */
            // LOAD ALL ADDRESSESS
            //List<Address> list = addressRepository.LoadAllAddressess();
            //foreach (Address a in list)
            //{
            //    Console.WriteLine(a.ToString());
            //}
            //address ("3270e5ea-2806-4543-acd8-2f43b9b9c8bf")
            //person 624dc3a6-7cb7-4fc0-a0bf-a648d15146d6
            // FIND ADDRESS BY ID
            //Address address = addressRepository.FindAddressByID("eae57032-0628-4345-acd8-2f43b9b9c8bf0");

            // FIND ADDRESS BY CITY NAME
            //List<Address> list = addressRepository.FindAddressByCityName("Skorenovac");
            //Console.WriteLine(list.Count);
            //foreach(Address address in list)
            //{
            //    Console.WriteLine(address.ToString());
            //}

            // FIND ADDRESS BY STREET NAME
            //List<Address> list = addressRepository.FindAddressByStreetName("ul. Smkokava");
            //foreach (Address address in list)
            //{
            //    Console.WriteLine(address.ToString());
            //}

            // DELETE ADDRESS
           // addressRepository.DeleteAddressById("f65a6b40-d4cc-4354-af46-bbebeafdf354");

            // UPDATE ADDRESS










            Console.WriteLine("\n");
        }
    }
}
