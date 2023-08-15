using Newtonsoft.Json;
using ViberAdapter.Models.Interfaces;

namespace ViberAdapter.Models
{
    /// <summary>
    /// Base user info.
    /// </summary>
    public class UserBase : IUserBase
    {
        /// <inheritdoc />
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <inheritdoc />
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}