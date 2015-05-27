using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Oversight.Models.DTO
{
    public class Task
    {
        public Task(int tId, string tName, string tSubtask, List<Status> tStatuses)
        {
            Id = tId;
            Name = tName;
            Subtask = tSubtask;
            Statuses = tStatuses;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subtask")]
        public string Subtask { get; set; }

        [JsonProperty("statuses")]
        public List<Status> Statuses { get; set; }
    }
}