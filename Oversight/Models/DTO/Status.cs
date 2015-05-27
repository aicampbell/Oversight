using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    /// <summary>
    /// Issue status
    /// </summary>
    public class Status
    {
        public Status(int sId, string sName, string sIconUrl, string sDescription)
        {
            Id = sId;
            Name = sName;
            IconUrl = sIconUrl;
            Description = sDescription;
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
