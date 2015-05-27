using Newtonsoft.Json;
using Oversight.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Web;

namespace Oversight.Models
{
    public enum JiraResource
    {
        project,
        issue,
        search,
        user
    }
    public class JiraClient
    {
        //Base Url for connecting the Jira
        private string baseUrl; 
        //Username for logging into account
        private string username;
        //Password for logging into account
        private string password; 
        private int startAt = 0;
        private int maxResults = 50;
        private string baseStatusUrl;

        public string BaseStatusUrl
        {
            get { return this.baseStatusUrl; }
            set { this.baseStatusUrl = value; }

        }

        //Default Constructor
        public JiraClient()
        {
            this.baseUrl = "https://oversight.atlassian.net/rest/api/2/";
            this.username = "admin";
            this.password = "password";
            this.BaseStatusUrl = "https://oversight.atlassian.net/rest/greenhopper/1.0/xboard/work/allData?rapidViewId=1";
        }


        public string RunQuery(string url, string argument = null, string data = null, string method = "GET")
        {

            // string url = string.Format("{0}{1}/", this.baseUrl, resource.ToString());

            if (argument != null)
            {
                url = string.Format("{0}{1}", url, argument);
            }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
            request.ContentType = "application/json";
            request.Method = method;

            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }

            string base64Credentials = GetEncodedCredentials();
            request.Headers.Add("Authorization", "Basic " + base64Credentials);

            string responseBody = string.Empty;

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseBody = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return responseBody;

        }

        public List<Project> GetProjects()
        {
            string responseBody = this.RunQuery(this.baseUrl + "project");
            return JsonConvert.DeserializeObject<List<Project>>(responseBody);
        }

        private string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", username, password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }

        /// <summary>
        /// Gets a list of issues using JQL
        /// </summary>
        /// <param name="jql">The Jira Query Language query</param>
        /// <param name="fields">List of fields to return</param>
        /// <returns></returns>
        public List<Issue> GetIssues(string jql, List<string> fields = null)
        {
            fields = fields ?? new List<string> { "summary", "description", "assignee", "status", "fixVersions", "updated"};

            SearchRequest request = new SearchRequest();
            //request.Fields = fields;
             request.JQL = jql;
            request.MaxResults = this.maxResults;
            request.StartAt = this.startAt;

            string data = JsonConvert.SerializeObject(request);

            string url = string.Format("{0}{1}", baseUrl, JiraResource.search.ToString());

            string result = RunQuery(url, data: data, method: "POST");

            SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(result);

            return response.IssueDescriptions;
        }

        public RootObject GetStatusNames()
        {
            string responseBody = this.RunQuery(this.BaseStatusUrl);
            return JsonConvert.DeserializeObject<RootObject>(responseBody);

        }

        public RootObject1 getSprintDetails()
        {
            string responseBody = this.RunQuery(this.BaseStatusUrl);
            return JsonConvert.DeserializeObject<RootObject1>(responseBody);
            
        }
 
        
    }
}