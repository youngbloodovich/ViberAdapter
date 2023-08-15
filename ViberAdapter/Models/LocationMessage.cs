using Newtonsoft.Json;
using ViberAdapter.Models.Enums;

namespace ViberAdapter.Models
{
    /// <summary>
    /// Location message.
    /// </summary>
    public class LocationMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMessage"/> class.
        /// </summary>
        public LocationMessage()
            : base(MessageType.Location)
        {
        }

        /// <summary>
        /// Location data.
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}