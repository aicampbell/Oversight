using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oversight.Models
{
    public class BurndownChartData
    {
        public BurndownChartData(DateTime bDate,int bActualStoryPoints,double bIdealStoryPoints)
        {
            date = bDate.ToString("yyyy-MM-dd");
            actualStoryPoints = bActualStoryPoints;
            idealStoryPoints = bIdealStoryPoints;
            
        }

        public string date { get; set; }

        public int actualStoryPoints { get; set; }
        public double idealStoryPoints { get; set; }
    }
}