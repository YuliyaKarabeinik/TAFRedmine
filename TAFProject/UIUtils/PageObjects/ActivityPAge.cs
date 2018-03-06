using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	class ActivityPage : BasePage
	{
	    readonly By activityContentLocator = By.Id("activity");
		BaseElement activityContent;

		public bool IsIssueAdded(string issueName)
		{
			activityContent = SearchElementUtil.GetElement(activityContentLocator);
			return activityContent.FindElements(By.XPath("//dl//a")).Any(element => element.Text == issueName);
		}
	}
}