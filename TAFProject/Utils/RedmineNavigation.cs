using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.Utils
{
    public enum Pages
    {
        Login, Home, Projects, NewProject, CurrentProject, NewIssue, Activity, Issues
    }
    class RedmineNavigation
    {
        static Browser browser = Browser.Instance;
        public string CurrentUrl { get; private set; }
        private string CurrentProjectIdentifier { get; } = "";

        readonly Dictionary<Pages, string> urls = new Dictionary<Pages, string>()
        {
            { Pages.Login, "http://icerow.com/"},
            { Pages.Home, "http://icerow.com/"},
            { Pages.Projects, "http://icerow.com/projects/"},
            { Pages.NewProject, "http://icerow.com/projects/new"},
            { Pages.CurrentProject, $"http:////icerow.com//projects//{CurrentProjectIdentifier}"},
            { Pages.NewIssue, $"http:////icerow.com//{CurrentProjectIdentifier}//issues//new"},
            { Pages.Activity, $"http:////icerow.com//projects//{CurrentProjectIdentifier}//activity"},
            { Pages.Issues, $"http:////icerow.com//projects//{CurrentProjectIdentifier}//issues"}
        };

        public string GetActivityUrl(string projectName)
        {
            string activityUrl = $"http:////icerow.com//projects//{projectName}//activity";
            return activityUrl;
        }

        public string GetAddIssueUrl(string projectName)
        {
            string addIssueUrl = $"http:////icerow.com//{projectName}//issues//new";
            return addIssueUrl;
        }

        public void GoToUrl(string url)
        {
            browser.GoToUrl(url);
            CurrentUrl = url;
        }

        //public void GoTo<>(Pages page)
        //{
        //    browser.GoToUrl(urls[page]);
        //}

    }
}
