using System;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
    class Navigation: INavigation
    {
		static Browser browser = Browser.Instance;


	    public string BaseUrl { get; set; } = "http://icerow.com/";
		public string AddProjectUrl { get; set; } = "http://icerow.com/projects/new";

	    public string getActivityUrl(string projectName)
	    {
		    string activityUrl = $"http:////icerow.com//projects//{projectName}//activity";
			return activityUrl;
		}
	    public string getAddIssueUrl(string projectName)
	    {
		    string addIssueUrl = $"http:////icerow.com//{projectName}//issues//new";
			return addIssueUrl;
	    }
		
	
		public void Back()
        {
           // throw new NotImplementedException();
        }

        public void Forward()
        {
            // throw new NotImplementedException();
        }

	    public void GoToUrl(string url)
	    {
		    browser.GoToUrl(url);
		}
	/*	public void GoToUrl(BasePage page)
        {
          browser.GoToUrl(page.BaseUrl);
        }
*/
        public void GoToUrl(Uri url)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
