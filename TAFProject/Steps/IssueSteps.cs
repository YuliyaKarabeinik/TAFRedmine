using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFProject.Models;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
	public static class IssueSteps
	{
		public static void AddIssue(string projectIdentifier, string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
			IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
		{
			var newIssue = RedmineNavigation.GoTo<NewIssuePage>(Pages.TemplateNewIssue, projectIdentifier);
			newIssue.SelectType(type);
			newIssue.SetSubject(issueSubject);
			newIssue.SetDescription(issueDescription);
			newIssue.SelectStatus(status);
			newIssue.SelectPriority(priority);
			newIssue.ClickCreate();
		}

		public static bool IsIssueCreated()
		{
			ActivityPage page = new ActivityPage();
			return page.IsIssueCreated("");//name or number of issue?
		}
	}
}
