using System;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
    public enum Pages
    {
        Login, Home, Projects, NewProject, CurrentProject, NewIssue, Activity, Issues
    }
    static class RedmineNavigation
    { 
        static Browser browser = Browser.Instance;
        public static string CurrentUrl { get; private set; }
        private static string CurrentProjectIdentifier { get; } = "";

        static readonly Dictionary<Pages, string> urls = new Dictionary<Pages, string>()
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
        
        public static void GoToUrl(string url)
        {
            browser.GoToUrl(url);
            CurrentUrl = url;
        }

        public static TPage GoTo<TPage>(Pages page, string projectIdentifier = "") where TPage : BasePage, new()
        {
            browser.GoToUrl($"urls[page]/{projectIdentifier}");
            CurrentUrl = urls[page];
            return new TPage();
        }
    }
}
