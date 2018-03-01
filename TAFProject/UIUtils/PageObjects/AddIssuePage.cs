using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	class AddIssuePage : BasePage
	{
		public override string BaseUrl { get; protected set; }
		private readonly string projectName;
		
		BaseElement newIssueButton, newIssueSubject, newIssueCommitButton;
		static BaseElement newIssueNumber = new BaseElement("//*[@id=\"flash_notice\"]/a");
		private string createdIssueNumber = GetIssueNumber();

		public AddIssuePage(string projectName)
		{
			this.projectName = projectName;
			BaseUrl = $"http://icerow.com/{projectName}/issues/new";
			newIssueButton = new BaseElement("//div[@class=\"contextual\"]/a");
			newIssueSubject = new BaseElement(By.Id("issue_subject"));
			newIssueCommitButton = new BaseElement(By.Name("commit"));
		}

		public static string GetIssueNumber()
		{
			return newIssueNumber.Text;
		}

		//public override void GoToPage()
		//{
		//	browser.GoToUrl(BASE_URL);
		//}

		public void CreateNewIssue(string issueName)
		{
			newIssueButton.Click();
			newIssueSubject.SendKeys(issueName);
			newIssueCommitButton.Click();
		}		
	}
}
