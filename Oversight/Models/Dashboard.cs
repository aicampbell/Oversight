using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oversight.Models.DTO;

namespace Oversight.Models
{
    public class Dashboard
    {
        public Sprint sprintDetails { get; set; }
        public List<Issue> CurrentIssues;
        public List<Issue> PreviousIssues;

        public List<Issue> NewIssues { get; set; }
        public List<Issue> RemovedIssues { get; set; }
        public List<Issue> ChangedIssuesRight { get; set; }
        public List<Issue> ChangedIssuesLeft { get; set; }
        public List<Column> ColumnNames { get; set; }
        public string PlaySound { get; set; }
        public List<int> NumberOfIssuesInEachColumn { get; set; }

        public List<BurndownChartData> BurndownChatData { get; set; }
        public ChartData ChartData { get; set; }
        public Dashboard()
        {
            PreviousIssues = null;
            ChangedIssuesRight = null;
            ChangedIssuesLeft = null;
            ColumnNames = null;
            NumberOfIssuesInEachColumn = new List<int>();
            PlaySound = " ";
        }

        public void setColumnColours()
        {
           List<string> colourArray = new List<string>();

           colourArray.Add("#00b1b2");
           colourArray.Add("#ff0000");
           colourArray.Add("#ff9a00");
           colourArray.Add("#0fd800");
           colourArray.Add("#7400ff");
           colourArray.Add("#ff5700");
           colourArray.Add("#666633");
           colourArray.Add("#1100d2");
           colourArray.Add("#d600a8");

           for (int i = 0; i < ColumnNames.Count; i++)
           {
               ColumnNames[i].colour = colourArray[i];
           }
        }
        public void countIssuesInEachColumn()
        {

            foreach (Column column in ColumnNames)
            {
                    NumberOfIssuesInEachColumn.Add(CurrentIssues.Count(s => column.statusIds.Contains(s.Fields.Status.Id.ToString()))); 

                // (myList.Any(str => str.Contains("Mdd LH")))
                // NumberOfIssuesInEachColumn.Add(CurrentIssues.Count(s => s.Fields.Status.Name.Equals(column.name))); 
            }
        }

        public void sortIssuesByDate()
        {
            foreach (Issue issue in CurrentIssues)
            {
                DateTime now = DateTime.Now;
                TimeSpan span = now.Subtract(issue.Fields.Date);

                issue.LastUpdated = span;
                CurrentIssues = new List<Issue>(CurrentIssues.OrderBy(time => time.LastUpdated));
            }
        }
        public void setIssuePositions()
        {
             foreach (Column column in ColumnNames)
            {
                var columnName = column.name;

                foreach (Issue issue in CurrentIssues)
                {
                    if (issue.Fields.Status.Name.Equals(columnName))
                    {
                        issue.Position = ColumnNames.FindIndex(position => position.name.Equals(issue.Fields.Status.Name));
                    }
                }
            }
        }

        public void determineIfSoundShouldBePlayed()
        {
             setIssuePositions();
            ChangedIssuesRight = CurrentIssues.Where(ci => PreviousIssues.Any(pi => (pi.Id == ci.Id) && (pi.Position < ci.Position))).ToList();
            if (ChangedIssuesRight.Count > 0)
            {
                PlaySound = "Good";
            }

            ChangedIssuesLeft = CurrentIssues.Where(ci => PreviousIssues.Any(pi => (pi.Id == ci.Id) && (pi.Position > ci.Position))).ToList();
            if (ChangedIssuesLeft.Count > 0)
            {
                PlaySound = "Bad";
            }

        }

       /** public void determineTicketMovedDirection()
        {
            for (int index = 0; index < CurrentIssues.Count; index++)
            {
                if((CurrentIssues[index].Id == PreviousIssues[index].Id)&&(CurrentIssues[index].Position > PreviousIssues[index].Position)){
                    CurrentIssues[index].DirectionMoved = "right";
                }
                else if((CurrentIssues[index].Id == PreviousIssues[index].Id)&&(CurrentIssues[index].Position < PreviousIssues[index].Position)){
                    CurrentIssues[index].DirectionMoved = "left";
                }
                else if ((CurrentIssues[index].Id == PreviousIssues[index].Id) && (CurrentIssues[index].Position == PreviousIssues[index].Position))
                {
                    CurrentIssues[index].DirectionMoved = PreviousIssues[index].DirectionMoved;
                }
            }
        }
        **/
    }
}