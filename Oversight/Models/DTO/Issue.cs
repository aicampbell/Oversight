
using System;
using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    public class Issue
    {
        private string keyString;
        private int position;

        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("key")]
        public string Key
        {
            get
            {
                return keyString;
            }
            set
            {
                keyString = value;
            }
        }

        [JsonIgnore]
        public IssueKey IssueId
        {
            get
            {
                return IssueKey.Parse(keyString);
            }
        }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        /// <summary>
        /// Combination of issue id and the summary field
        /// </summary>
        [JsonIgnore]
        public String Title
        {
            get
            {
                return string.Format("[{0}] {1}", keyString, Fields.Summary);
            }
        }
        public int Position { get; set; }

        public TimeSpan LastUpdated { get; set; }

        public string DirectionMoved = null;

    }

}