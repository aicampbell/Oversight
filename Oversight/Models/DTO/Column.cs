using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models.DTO
{
    public class Column
    {
            public int id { get; set; }
            public string name { get; set; }
            public List<string> statusIds { get; set; }
            public string colour { get; set; }
    }
}