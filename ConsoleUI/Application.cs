using ContactManagerLibrary;
using ContactManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        private readonly IContactHandler contactHandler;
        private readonly IConsoleEmailer emailer;
        public Application(IContactHandler contactHandler, IConsoleEmailer emailer)
        {
            this.contactHandler = contactHandler;
            this.emailer = emailer;
        }

        public void Run()
        {
            while (true)
            {
                //Get user input and skip rest of the iteration if no search term is given.
                Console.Write("Enter a search term: ");
                string input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                //Get the filtered list and check that it isn't empty.
                List<ContactModel> contacts = contactHandler.GetContactsByName(input);
                if (contacts.Count == 0)
                {
                    Console.WriteLine("No results found with the given search term.");
                }
                else
                {
                    //Run Mail with selector.
                    emailer.SendEmail(SelectContact(contacts));
                }

                //Wait a second before clearing screen.
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        private ContactModel SelectContact(List<ContactModel> contacts)
        {
            //Throw if we have a empty list.
            if (contacts.Count == 0)
                throw new ArgumentException("Given list was empty.", nameof(contacts));

            //Return immediately if list only has one entry.
            if (contacts.Count == 1)
            {
                return contacts[0];
            }

            //Iterate over the list and print contents on screen.
            Console.WriteLine("Multiple contacts found, choose one to use.");
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"[{i}] {contacts[i].FullName} @ {contacts[i].Email}");
            }

            Console.WriteLine();
            Console.Write("Selection: ");

            //Loop until function returns.
            while (true)
            {
                //Skip rest of the loop if user entered a non-digit value.
                if (!Int32.TryParse(Console.ReadLine(), out int selection))
                {
                    Console.WriteLine($"Not a valid number, enter a number between '0' and '{contacts.Count - 1}'.");
                    continue;
                }

                //Skip rest if selection outside of range.
                if (selection < 0 || selection > contacts.Count - 1)
                {
                    Console.WriteLine($"Enter a number between '0' and '{contacts.Count - 1}'");
                    continue;
                }

                //If both checks pass return selected item.
                return contacts[selection];
            }
        }
    }
}
