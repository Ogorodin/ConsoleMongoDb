using System;
using ConsoleMongoDb.Helpers;
using Printer;

namespace ConsoleMongoDb
{
    class Program
    {
        static void Main(string[] args)
        {

            GUI gui = new GUI();
            gui.LoadMenu();

            Console.WriteLine("\n");
        }
    }
}
