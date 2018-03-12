using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    class ActivityPage : BasePage
    {
        static readonly By activityContentLocator = By.Id("activity");
        BaseElement activityContent;

        public bool IsIssueCreated(string issueName)
        {
            activityContent = SearchElementUtil.GetElement(activityContentLocator);
			return activityContent.FindElements(By.XPath("//dt//a")).Any(element => element.Text.Contains(issueName));
        }
    }
}