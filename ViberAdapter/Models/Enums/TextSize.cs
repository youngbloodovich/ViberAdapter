﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ViberAdapter.Models.Enums
{
    /// <summary>
    /// Text size.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextSize
    {
        /// <summary>
        /// Size 'small'.
        /// </summary>
        [EnumMember(Value = "small")]
        Small = 1,

        /// <summary>
        /// Size 'regular'.
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular = 2,

        /// <summary>
        /// Size 'large'.
        /// </summary>
        [EnumMember(Value = "large")]
        Large = 3
    }
}