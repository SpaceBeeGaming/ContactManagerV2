using System;

namespace ContactManagerLibrary.Utilities
{
    public class SimEmailer : IEmailer
    {
        public void SendEmail(string adderss, string title, string message)
        {
            Console.WriteLine($"Simulated email to:");
            Console.WriteLine($"To: {adderss}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
