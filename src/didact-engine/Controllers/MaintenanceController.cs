using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DidactEngine.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ILogger<MaintenanceController> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public MaintenanceController(ILogger<MaintenanceController> logger, IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        /// <summary>
        /// Returns a 200 heartbeat to show the caller that it has access to the API.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/heartbeat")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public IActionResult GetHeartbeat()
        {
            return Ok();
        }

        /// <summary>
        /// Shuts down the API. Most likely, the API will be running behind a traditional web server, so the next request to the API will revive it.
        /// This will potentially be used to restart the API once a new set of DLL files are detected.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/shutdown")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        public IActionResult ShutdownApplication()
        {
            _logger.LogCritical("Shutting down the application via the /shutdown endpoint...");
            _hostApplicationLifetime.StopApplication();
            return Ok("Didact Engine is now shutting down.");
        }
    }
}
