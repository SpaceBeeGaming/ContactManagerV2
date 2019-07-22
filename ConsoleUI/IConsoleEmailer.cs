using ContactManagerLibrary.Models;

namespace ConsoleUI
{
    public interface IConsoleEmailer
    {
        void SendEmail(ContactModel contact);
    }
}