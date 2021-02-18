using System;
using ConsoleMongoDb.Helpers;
using ConsoleMongoDb.Repository;
using Printer;

namespace ConsoleMongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonRepository repository = new PersonRepository(Constants.DatabaseName);
            GUI gui = new GUI(repository);
            gui.LoadMenu();

            Console.WriteLine("\n");
        }
    }
}
