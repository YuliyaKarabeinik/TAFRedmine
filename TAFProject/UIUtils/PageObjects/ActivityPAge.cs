using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    class ActivityPage : BasePage
    {
        string projectName;
        BaseElement activityContent;

        public ActivityPage(string projectName)
        {
            this.projectName = projectName;
            activityContent = new BaseElement(By.Id("activity"));
        }

        public bool IsIssueAdded(string issueName)
        {
            return activityContent.FindElements(By.XPath("//dl//a")).Any(element => element.Text.Contains(issueName));
        }
		
    }
}