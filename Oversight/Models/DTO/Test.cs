using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models.DTO
{
    public class Test
    {
    }
    public class Sprint
    {
        public int id { get; set; }
        public int sequence { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public int linkedPagesCount { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string completeDate { get; set; }
        public List<object> remoteLinks { get; set; }
        public int daysRemaining { get; set; }
    }

    public class SprintsData
    {
        public int rapidViewId { get; set; }
        public List<Sprint> sprints { get; set; }
        public bool canManageSprints { get; set; }
    }


    public class RootObject1
    {
        public int rapidViewId { get; set; }


        public SprintsData sprintsData { get; set; }
    }
}