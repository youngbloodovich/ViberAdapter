﻿using Newtonsoft.Json;
using ViberAdapter.Models.Enums;

namespace ViberAdapter.Models
{
    /// <summary>
    /// Contact message.
    /// </summary>
    public class ContactMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMessage"/> class.
        /// </summary>
        public ContactMessage()
            : base(MessageType.Contact)
        {
        }

        /// <summary>
        /// Contact object.
        /// </summary>
        [JsonProperty("contact")]
        public Contact Contact { get; set; }
    }
}