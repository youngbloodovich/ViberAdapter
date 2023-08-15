using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViberAdapter.Models.Enums
{
    /// <summary>
    /// Chat member role.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChatMemberRole
    {
        /// <summary>
        /// Role "admin".
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Role "participant".
        /// </summary>
        Participant = 2
    }
}