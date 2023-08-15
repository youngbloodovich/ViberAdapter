using Microsoft.AspNetCore.Mvc;
using ViberAdapter.Models;

namespace ViberAdapter.Controllers
{
    [ApiController]
    [Route("callback")]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _logger;

        public CallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Callback([FromBody] CallbackData contract)
        {
            _logger.LogInformation($"Callback received! Contract: {contract}");

            return Ok();
        }
    }
}
