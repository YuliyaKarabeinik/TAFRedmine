using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
	public static class Steps
	{
		public static void Login(string login, string password)
		{
			LoginPage loginPage = new LoginPage();
			loginPage.WriteUser(login);
			loginPage.WritePassword(password);
			loginPage.ClickSubmit();
			RedmineNavigation.GoTo<HomePage>(Pages.Home);
		}

		public static bool IsLogIn(string user = "")
		{
			HomePage homepage = new HomePage();
			if (user == string.Empty)
				return homepage.IsLogIn();
			return homepage.GetCurrentUser() == user;
		}

		public static void LogOut()
		{
			HomePage homepage = new HomePage();
			homepage.LogoutHomePage();
		}

		public static void AddProject(string projectName, string projectIdentifier)
		{
			RedmineNavigation.GoTo<AddProjectPage>(Pages.NewProject);
			var newProject = new AddProjectPage();
			newProject.WriteName(projectName);
			newProject.WriteIdentifier(projectIdentifier);
			newProject.ClickCreate();
		}

		public static bool IsProjectCreated()
		{
			AddProjectPage page = new AddProjectPage();
			return page.IsPositiveNotificationAppear();
		}
        
		public static bool IsProjectCreationFailed()
		{
			AddProjectPage page = new AddProjectPage();
			return page.IsNegativeNotificationAppear();
		}

		public static void AddIssue(string projectIdentifier, string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
			IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
		{
			RedmineNavigation.GoTo<AddIssuePage>(Pages.NewIssue, projectIdentifier);
			var newIssue = new AddIssuePage();
			newIssue.ChooseType(type);
			newIssue.WriteSubject(issueSubject);
			newIssue.WriteDescription(issueDescription);
			newIssue.ChooseStatus(status);
			newIssue.ChoosePriority(priority);
			newIssue.ClickCreate();
		}
	}
}
