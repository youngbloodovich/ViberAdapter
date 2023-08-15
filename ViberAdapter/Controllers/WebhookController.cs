using Microsoft.AspNetCore.Mvc;
using ViberAdapter.Services;

namespace ViberAdapter.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        private readonly IWebhookService _webhookService;

        public WebhookController(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        [HttpGet("create")]
        public async Task<IActionResult> SetWebook()
        {
            var result = await _webhookService.Create();
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("delete")]
        public async Task<IActionResult> RemoveWebhook()
        {
            var result = await _webhookService.Delete();
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
