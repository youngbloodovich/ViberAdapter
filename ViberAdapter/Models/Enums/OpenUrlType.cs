using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ViberAdapter.Models.Enums
{
    /// <summary>
    /// Determine the open-url action result, in app or external browser.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OpenUrlType
    {
        /// <summary>
        /// Type 'internal'.
        /// </summary>
        [EnumMember(Value = "internal")]
        Internal = 1,

        /// <summary>
        /// Type 'external'.
        /// </summary>
        [EnumMember(Value = "external")]
        External = 2
    }
}