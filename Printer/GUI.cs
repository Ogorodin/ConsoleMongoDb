﻿using ConsoleMongoDb.Entity;
using ConsoleMongoDb.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Printer
{
    class GUI
    {

        private readonly PersonRepository mongoCrud;


        public GUI()
        {
            mongoCrud = new PersonRepository("usersDB");
            Console.WriteLine("Welcome to your personal address book.");
        }
        public void LoadMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create new record.");
            Console.WriteLine("2. Find users by last name.");
            Console.WriteLine("3. Update record.");
            Console.WriteLine("4. Delete record by last name.");
            Console.WriteLine("5. Delete record by ID.");
            Console.WriteLine("6. List all.");
            Console.WriteLine("0. Exit.\n");



            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    // exit program.
                    break;
                case 1: // CREATE USERs
                    Console.WriteLine("Insert first name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Insert last name: ");
                    string lastName = Console.ReadLine();
                    Person person = new Person
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };
                    mongoCrud.InsertRecord<Person>(Constants.CollectionName_users, person);
                    LoadMenu();
                    break;

                case 2: // FIND BY LAST NAME

                    Console.WriteLine("Insert last name: ");
                    var user_input = Console.ReadLine();

                    List<Person> listOfUsers = mongoCrud.FindPersonByLastName(Constants.CollectionName_users, user_input);
                    Console.WriteLine(listOfUsers.Count);
                    if (listOfUsers.Count < 1)
                    {
                        Console.WriteLine("Not found.");
                        Console.WriteLine("Press any key to continue: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Documents matching the search criteria:\n");
                        Console.WriteLine("-------------------------------------");
                        int counter = 1;
                        foreach (Person p in listOfUsers)
                        {
                            Console.WriteLine($"{counter}. {p.FirstName} {p.LastName}");
                            counter++;
                            Console.WriteLine("-------------------------------------");
                        }
                    }

                    LoadMenu();
                    break;
                case 3:
                    LoadMenu();
                    break;

                case 4: // DELETE BY LAST NAME
                    {
                        Console.WriteLine("Enter the last for the record you want to delete: ");
                        string ln = Console.ReadLine();
                        long deleteCount = mongoCrud.DeleteByLastName("users", ln);
                        Console.WriteLine($"Number of records deleted is: {deleteCount}");
                        LoadMenu();
                        break;
                    }

                case 5: // DELETE BY ID
                    {
                        Console.WriteLine("Enter the ID for the record you want to delete: ");
                        string id = Console.ReadLine();
                        if (mongoCrud.DeleteById("users", id).IsAcknowledged)
                        {
                            Console.WriteLine($"Record with ID {id} is deleted.");
                        }
                        else
                        {
                            Console.WriteLine($"There is no record with the ID: {id}. Nothing was deleted");
                        }
                        LoadMenu();
                        break;
                    }

                case 6: // FIND ALL
                    var records = mongoCrud.LoadRecords<Person>(Constants.CollectionName_users);
                    Console.WriteLine("This is the entire users list\n");
                    Console.WriteLine("==================================================================================");
                    Console.WriteLine("|  ID \t\t\t\t\t | FIRST NAME \t\t|  LAST NAME \t |");
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (var rec in records)
                    {
                        Console.WriteLine($"| {rec.Id} \t | {rec.FirstName}\t\t| {rec.LastName}\t |");
                    }
                    Console.WriteLine("==================================================================================");
                    LoadMenu();
                    break;

                default: // INVALID USER INPUT
                    Console.WriteLine("Invalid input. Try again.\n");
                    LoadMenu();
                    break;

            }
        }




    }
}
