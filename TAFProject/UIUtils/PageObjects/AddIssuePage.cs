using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public enum IssueType
	{
		Default, Task, ChangeRequest
	}
	public enum IssueStatus
	{
		Default, New, NeedInfo, Assigned, Closed
	}
	public enum IssuePriority
	{
		Default, Lowest, Low, Medium, High, Highest
	}
	class AddIssuePage : BasePage
	{
		public override string BaseUrl { get; protected set; }
		private readonly string projectName;


		private SelectElement comboboxIssueType, comboboxStatus, comboboxPriority;
		BaseElement textboxSubject, textboxDescription, buttonCommitCreation;
		//static BaseElement newIssueNumber = new BaseElement("//*[@id=\"flash_notice\"]/a");
		//private string createdIssueNumber = GetIssueNumber();

		public AddIssuePage(string projectName)
		{
			this.projectName = projectName;
			BaseUrl = $"http:////icerow.com//{this.projectName}//issues//new";

			comboboxIssueType = new SelectElement(new BaseElement("//select[@id='issue_tracker_id']"));
			textboxSubject = new BaseElement("//input[@id='issue_subject']");
			textboxDescription = new BaseElement("//textarea[@id='issue_description']");
			comboboxStatus = new SelectElement(new BaseElement("//select[@id='issue_status_id']"));
			comboboxPriority = new SelectElement(new BaseElement("//select[@id='issue_priority_id']"));
			buttonCommitCreation = new BaseElement("//input[@type='submit'][@name = 'commit']");
		}

		//public static string GetIssueNumber()
		//{
		//	return newIssueNumber.Text;
		//}

		public void CreateNewIssue(string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
			IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
		{
			if (type != IssueType.Default)
				comboboxIssueType.SelectByText(type.ToString().Replace(" ", ""));
			textboxSubject.SendKeys(issueSubject);
			textboxDescription.SendKeys(issueDescription);
			if (status != IssueStatus.Default)
				comboboxStatus.SelectByText(status.ToString().Replace(" ", ""));
			if (priority != IssuePriority.Default)
				comboboxPriority.SelectByText(priority.ToString());
			buttonCommitCreation.Click();
		}

		//public override void GoToPage()
		//{
		//	browser.GoToUrl(BaseUrl);
		//}
	}
}