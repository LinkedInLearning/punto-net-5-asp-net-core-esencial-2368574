using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace di
{
    public class MyMiddleware
    {
        private readonly RequestDelegate nextMiddleware;

        public MyMiddleware(RequestDelegate next)
        {
            nextMiddleware = next;
        }

        public async Task InvokeAsync(HttpContext context, IEmailSenderService emailSenderService)
        {
            emailSenderService.Send(null, null, null);
            await nextMiddleware(context);
        }
    }
}