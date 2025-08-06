using DidactUi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DidactUi.Controllers
{
    public class EnvironmentVariablesController : ControllerBase
    {
        private readonly ILogger<EnvironmentVariablesController> _logger;
        private readonly UiSettings _uiSettings;

        public EnvironmentVariablesController(ILogger<EnvironmentVariablesController> logger, UiSettings uiSettings)
        {
            _logger = logger;
            _uiSettings = uiSettings;
        }

        [HttpGet("environment-variables")]
        public IActionResult GetEnvironmentVariables()
        {
            return Ok(_uiSettings);
        }
    }
}
