using System;
using System.Collections.Generic;
using Oversight.Models;
using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    /// <summary>
    /// Fields for an Issue
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// The summary of an issue
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// The status of an issue
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The user an issue is assigned to
        /// </summary>
        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }

        /// <summary>
        /// The description of an issue
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The fix versions of an issue
        /// </summary>
        [JsonProperty("fixVersions")]
        public List<Iteration> FixVersions { get; set; }

        /// <summary>
        /// The customfield used for acceptance criteria
        /// </summary>
        [JsonProperty("customfield_10101")]
        public string AcceptanceCriteria { get; set; }

        [JsonProperty("updated")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The customfield used for story points
        /// </summary>
        [JsonProperty("customfield_10005")]
        public string StoryPoints { get; set; }

    }
}
