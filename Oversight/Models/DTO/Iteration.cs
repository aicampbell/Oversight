using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    /// <summary>
    /// Represents a Jira fix version attached to an issue
    /// </summary>
    public class Iteration
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("released")]
        public bool Released { get; set; }

    }
}
