using System;
using System.Diagnostics;

namespace di
{
    public class EmailSenderService : IEmailSenderService
    {
        Guid newId;
        public EmailSenderService()
        {
            newId = Guid.NewGuid();
        }
        public void Send(string from, string to, string body)
        {
            Debug.WriteLine($"{newId}");
        }
    }
}