using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models.DTO
{
    public class ColumnData
    {
            public int rapidViewId { get; set; }
            public List<Column> columns { get; set; }
    }
    public class RootObject
    {
        public ColumnData columnsData { get; set; }
        public SprintsData sprintData { get; set; }
    }
}