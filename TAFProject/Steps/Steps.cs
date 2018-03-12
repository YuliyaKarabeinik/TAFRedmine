using TAFProject.Models;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
    public static class Steps
    {
        public static void Login(string login, string password)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.SetUser(login);
            loginPage.SetPassword(password);
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
            RedmineNavigation.GoTo<NewProjectPage>(Pages.NewProject);
            var newProject = new NewProjectPage();
            newProject.SetName(projectName);
            newProject.SetIdentifier(projectIdentifier);
            newProject.ClickCreate();
        }

        public static bool IsProjectCreated()
        {
            NewProjectPage page = new NewProjectPage();
            return page.IsSuccessfulCreation();
        }

	    public static bool IsProjectCreated(out string notificationText)
	    {
		    NewProjectPage page = new NewProjectPage();
		    notificationText = page.GetNotificationAboutCreationText();
		    return page.IsSuccessfulCreation();
	    }

		public static void AddIssue(string projectIdentifier, string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
            IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
        {
            RedmineNavigation.GoTo<NewIssuePage>(Pages.TemplateNewIssue, projectIdentifier);
            var newIssue = new NewIssuePage();
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
