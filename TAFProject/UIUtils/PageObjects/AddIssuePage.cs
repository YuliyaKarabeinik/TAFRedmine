using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public enum IssueType  //Models
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
	public class AddIssuePage : BasePage
	{
	    readonly Dictionary<string, By> locators = new Dictionary<string, By>()
		{
			{ "type", By.XPath("//select[@id='issue_tracker_id']") },
			{ "subject", By.XPath("//input[@id='issue_subject']") },
			{ "description", By.XPath("//textarea[@id='issue_description']") },
			{ "status", By.XPath("//input[@id='project_homepage']") },
			{ "priority", By.XPath("//input[@id='project_is_public']") },
			{ "buttonCreate", By.XPath("//select[@id='project_parent_id']") }
		};
		SelectElement comboboxIssueType, comboboxStatus, comboboxPriority;
		BaseElement textboxSubject, textboxDescription, buttonCreate;

		//static BaseElement newIssueNumber = new BaseElement("//*[@id=\"flash_notice\"]/a");
		//private string createdIssueNumber = GetIssueNumber();

		//public static string GetIssueNumber()
		//{
		//	return newIssueNumber.Text;
		//}
		public void ChooseType(IssueType type) //SelectType
		{
			comboboxIssueType = new SelectElement(SearchElementUtil.GetElement(locators["type"]));
			if (type != IssueType.Default)
				comboboxIssueType.SelectByText(type.ToString().Replace(" ", ""));
		}
		public void WriteSubject(string issueSubject)
		{
			textboxSubject = SearchElementUtil.GetElement(locators["subject"]);
			textboxSubject.SendKeys(issueSubject);
		}
		public void WriteDescription(string issueDescription)
		{
			textboxDescription = SearchElementUtil.GetElement(locators["description"]);
			textboxDescription.SendKeys(issueDescription);
		}
		public void ChooseStatus(IssueStatus status)
		{
			comboboxStatus = new SelectElement(SearchElementUtil.GetElement(locators["status"]));
			if (status != IssueStatus.Default)
				comboboxStatus.SelectByText(status.ToString().Replace(" ", ""));
		}
		public void ChoosePriority(IssuePriority priority)
		{
			comboboxPriority = new SelectElement(SearchElementUtil.GetElement(locators["priority"]));
			if (priority != IssuePriority.Default)
				comboboxPriority.SelectByText(priority.ToString());
		}
		public void ClickCreate()
		{
			buttonCreate = SearchElementUtil.GetElement(locators["buttonCreate"]);
			buttonCreate.Click();
		}
	}
}