﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ViberAdapter.Models.Enums
{
    /// <summary>
    /// Vertical alignment of the text.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextVerticalAlign
    {
        /// <summary>
        /// Align 'top'.
        /// </summary>
        [EnumMember(Value = "top")]
        Top = 1,

        /// <summary>
        /// Align 'middle'.
        /// </summary>
        [EnumMember(Value = "middle")]
        Middle = 2,

        /// <summary>
        /// Align 'bottom'.
        /// </summary>
        [EnumMember(Value = "bottom")]
        Bottom = 3
    }
}