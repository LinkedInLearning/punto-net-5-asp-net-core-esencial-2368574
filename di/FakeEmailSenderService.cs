using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace di
{
    public class FakeEmailSenderService : IEmailSenderService
    {
        public void Send(string from, string to, string body)
        {
            //
        }
    }
}
