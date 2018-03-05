using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    class ActivityPage : BasePage
    {
        By activityContentLocator = By.Id("activity");
		BaseElement activityContent;
		public string ProjectName { get; private set; }

		public ActivityPage(string projectName)
        {
            ProjectName = projectName;
            activityContent = SearchElementUtil.GetElement(activityContentLocator);
        }

        public bool IsIssueAdded(string issueName)
        {
            return activityContent.FindElements(By.XPath("//dl//a")).Any(element => element.Text==issueName);
        }		
    }
}