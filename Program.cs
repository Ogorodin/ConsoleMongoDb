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


            IGenericRepository<Address> repository = new GenericRepository<Address>(Constants.DatabaseName, Constants.CollectionName_address);

            repository.DeleteRecord("eae57032-0628-4345-acd8-2f43b9b9c8bf");

            List<Address> list = repository.LoadAllRecords();

            foreach (Address p in list)
            {
                Console.WriteLine(p.ToString());
            }


            Console.WriteLine("\n");
        }
    }
}
