using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
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
        public IActionResult Callback(CallbackData? contract)
        {
            _logger.LogInformation($"Callback received! Contract: { JsonConvert.SerializeObject(contract) }");

            return Ok();
        }
    }
}
