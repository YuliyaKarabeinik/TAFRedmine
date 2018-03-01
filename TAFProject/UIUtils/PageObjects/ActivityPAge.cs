using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	class ActivityPage : BasePage
	{
	//	public override string BaseUrl { get; protected set; }
		string projectName;
		BaseElement activityContent;

		public ActivityPage(string projectName)
		{
			this.projectName = projectName;
	//		BaseUrl = $"http:////icerow.com//projects//{this.projectName}//activity";
			activityContent = new BaseElement(By.Id("activity"));
		}

		public bool IsIssueAdded(string issueName)
		{
			return activityContent.FindElements(By.XPath("//dl//a")).Any(element => element.Text.Contains(issueName));
		}
	}
}