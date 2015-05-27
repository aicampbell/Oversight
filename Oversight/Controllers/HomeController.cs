using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oversight.Models;
using Oversight.Models.DTO;

namespace Oversight.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dashboard dashboard = new Dashboard();
             JiraClient client = new JiraClient();

            var columns = client.GetStatusNames();
            dashboard.ColumnNames = columns.columnsData.columns;
            dashboard.setColumnColours();

            var sprintsData = client.getSprintDetails().sprintsData;
            dashboard.sprintDetails = sprintsData.sprints.Find(sprint => sprint.state.Equals("ACTIVE"));
          

            if (Session["PreviousIssues"] != null)
            {
                dashboard.PreviousIssues = (List<Issue>)Session["PreviousIssues"];
                dashboard.CurrentIssues = client.GetIssues("project = OV AND Sprint in openSprints()");
                dashboard.CurrentIssues = dashboard.CurrentIssues.OrderBy(o => o.Id).ToList();
                dashboard.setIssuePositions();
                dashboard.countIssuesInEachColumn();
                dashboard.determineIfSoundShouldBePlayed();
                Session["PreviousIssues"] = dashboard.CurrentIssues;
                dashboard.sortIssuesByDate();

                
               
            }
            else
            {
                dashboard.CurrentIssues = client.GetIssues("project = OV AND Sprint in openSprints()");
                Session["PreviousIssues"] = dashboard.CurrentIssues;
                dashboard.CurrentIssues = dashboard.CurrentIssues.OrderBy(o => o.Id).ToList();
                dashboard.setIssuePositions();
                dashboard.countIssuesInEachColumn();
                dashboard.sortIssuesByDate();
                
            }

            
            
            return View(dashboard);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}