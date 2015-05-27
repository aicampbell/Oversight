using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models
{
    public class ChartData
    {
        public ChartData(int cValue, String cColor, string cHighLight, string cLabel)
        {
            value = cValue;
            label = cLabel;
            highlight = cHighLight;
            color = cColor;
        }

        public int value { get; set; }
        public string color { get; set; }
        public string highlight { get; set; }
        public string label { get; set; }
    }
}