using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace di.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        IEmailSenderService emailSenderService;
        private readonly ILogger<EmailController> logger;

        public EmailController(IEmailSenderService emailSenderService,
        ILogger<EmailController> logger)
        {
            this.emailSenderService = emailSenderService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            logger.LogInformation("Enviando correo electrónico...");
            logger.LogError("Ha ocurrido un error");
            emailSenderService.Send(null, null, null);
            return Ok();
        }
    }
}