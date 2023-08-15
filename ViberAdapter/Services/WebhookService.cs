using Microsoft.Extensions.Options;
using ViberAdapter.Clients;
using ViberAdapter.Models;
using ViberAdapter.Models.Enums;
using ViberAdapter.Models.Settings;

namespace ViberAdapter.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly string _callbackEndpoint;
        private readonly IViberClient _viberClient;
        private readonly ILogger<WebhookService> _logger;

        public WebhookService(IOptions<ViberSettings> settings, IViberClient viberClient, ILogger<WebhookService> logger)
        {
            _callbackEndpoint = settings.Value.CallbackEndpoint;
            _viberClient = viberClient;
            _logger = logger;
        }

        public async Task<bool> Create()
        {
            try
            {
                await _viberClient.SetWebhookAsync(_callbackEndpoint, new EventType[]
                {
                    EventType.Delivered,
                    EventType.Seen,
                    EventType.Failed,
                    EventType.Subscribed,
                    EventType.Unsubscribed,
                    EventType.ConversationStarted,
                    EventType.Message
                });
            }
            catch (ViberRequestApiException e)
            {
                _logger.LogError(e, "Webhook creation error");
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong");
                return false;
            }

            _logger.LogInformation($"Webhook was created");
            return true;
        }

        public async Task<bool> Delete()
        {
            try
            {
                await _viberClient.SetWebhookAsync(_callbackEndpoint, new EventType[]
                {
                    EventType.Delivered,
                    EventType.Seen,
                    EventType.Failed,
                    EventType.Subscribed,
                    EventType.Unsubscribed,
                    EventType.ConversationStarted,
                    EventType.Message
                });
            }
            catch (ViberRequestApiException e)
            {
                _logger.LogError(e, "Webhook deletion error");
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong");
                return false;
            }

            _logger.LogInformation($"Webhook was deleted");
            return true;
        }
    }
}
