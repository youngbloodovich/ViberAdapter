using Microsoft.AspNetCore.Mvc;
using ViberAdapter.Clients;
using ViberAdapter.Models;

namespace ViberAdapter.Controllers
{
    [ApiController]
    [Route("callback")]
    public class CallbackController : ControllerBase
    {
        private readonly IViberClient _viberClent;
        private readonly ILogger<CallbackController> _logger;

        public CallbackController(IViberClient viberClent, ILogger<CallbackController> logger)
        {
            _viberClent = viberClent;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CallbackAsync(CallbackData? contract)
        {
            if (contract == null)
            {
                return BadRequest();
            }

            switch (contract.Event)
            {
                case Models.Enums.EventType.Delivered:
                    break;
                case Models.Enums.EventType.Seen:
                    break;
                case Models.Enums.EventType.Failed:
                    break;
                case Models.Enums.EventType.Subscribed:
                    await _viberClent.SendTextMessageAsync(new TextMessage()
                    {
                        Receiver = contract.User.Id,
                        Text = "Subscribed",
                    });
                    break;
                case Models.Enums.EventType.Unsubscribed:
                    await _viberClent.SendTextMessageAsync(new TextMessage()
                    {
                        Receiver = contract.User.Id,
                        Text = "Unsubscribed",
                    });
                    break;
                case Models.Enums.EventType.ConversationStarted:
                    await _viberClent.SendTextMessageAsync(new TextMessage()
                    {
                        Receiver = contract.User.Id,
                        Text = "ConversationStarted",
                    });
                    break;
                case Models.Enums.EventType.Message:
                    await _viberClent.SendTextMessageAsync(new TextMessage()
                    {
                        Receiver = contract.Sender.Id,
                        Text = "Message",
                    });
                    break;
                case Models.Enums.EventType.Webhook:
                    break;
                case Models.Enums.EventType.Action:
                    break;
                case Models.Enums.EventType.ClientStatus:
                    break;
                default:
                    _logger.LogWarning($"Undefined event: { contract.Event } !");
                    break;
            }

            return Ok();
        }
    }
}
