using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace testoptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        private CourseConfiguration courseConfiguration;
        private readonly ILogger<OptionsController> _logger;
        public OptionsController(ILogger<OptionsController> logger,
        IOptions<CourseConfiguration> courseConfiguration)
        {
            _logger = logger;
            this.courseConfiguration = courseConfiguration.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(courseConfiguration);
        }
    }
}