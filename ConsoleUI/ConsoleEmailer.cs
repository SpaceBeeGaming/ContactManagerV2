using ContactManagerLibrary.Models;
using ContactManagerLibrary.Utilities;
using System;

namespace ConsoleUI
{
    public class ConsoleEmailer : IConsoleEmailer
    {
        private readonly IEmailer emailer;

        public ConsoleEmailer(IEmailer emailer) => this.emailer = emailer;

        public void SendEmail(ContactModel contact)
        {
            Console.WriteLine($"Send email to '{contact.FullName}' @ '{contact.Email}'? [y/N]: ");
            ConsoleKey key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine("Sending Email.");
                emailer.SendEmail(contact.Email, title: "Test Email", message: "Hello, World!");
            }
            else
            {
                Console.WriteLine("Cancelling.");
            }
        }
    }
}
