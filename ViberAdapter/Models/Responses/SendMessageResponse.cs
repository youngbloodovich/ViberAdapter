using Newtonsoft.Json;

namespace ViberAdapter.Models.Responses
{
    /// <summary>
    /// Send message response.
    /// </summary>
    internal class SendMessageResponse : ApiResponseBase
    {
        /// <summary>
        /// Unique id of the message.
        /// </summary>
        [JsonProperty("message_token")]
        public long MessageToken { get; set; }
    }
}