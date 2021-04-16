namespace di
{
    public interface IEmailSenderService
    {
        void Send(string from, string to, string body);
    }
}