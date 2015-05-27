﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models.DTO
{
    /// <summary>
    /// Issue assignee
    /// </summary>
    public class Assignee
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
