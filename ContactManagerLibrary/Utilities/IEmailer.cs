namespace ContactManagerLibrary.Utilities
{
    public interface IEmailer
    {
        void SendEmail(string address, string title, string message);
    }
}