using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
	public static class IssueSteps
	{
		public static void AddIssue(IBrowser browser, string projectIdentifier, string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
			IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
		{
			var newIssue = RedmineNavigation.GoTo<NewIssuePage>(browser, Pages.TemplateNewIssue, projectIdentifier);
			newIssue.driver = browser.Driver;////Navigation problems
			newIssue.SelectType(type);
			newIssue.SetSubject(issueSubject);
			newIssue.SetDescription(issueDescription);
			newIssue.SelectStatus(status);
			newIssue.SelectPriority(priority);
			newIssue.ClickCreate();
		}

		public static bool IsIssueCreated(IBrowser browser, string projectIdentifier, string issueName)
		{
			var activity = RedmineNavigation.GoTo<ActivityPage>(browser, Pages.TemplateActivity, projectIdentifier);
			activity.driver = browser.Driver;//Navigation problems
			return activity.IsIssueCreated(browser.Driver, issueName); //name or number of issue?
		}
	}
}
