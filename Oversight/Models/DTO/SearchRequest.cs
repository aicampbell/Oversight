using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    /// <summary>
    /// Search parameters for querying issues
    /// </summary>
    public class SearchRequest
    {
        [JsonProperty("jql")]
        public string JQL { get; set; }

        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("fields")]
        public List<string> Fields { get; set; }

        public SearchRequest()
        {
            Fields = new List<string>();
        }
    }
}
