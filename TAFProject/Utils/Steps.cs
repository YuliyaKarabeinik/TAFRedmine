using System.Threading;
using OpenQA.Selenium;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
    public static class Steps
    {
        public static HomePage Login(string login, string password)
        {
            LoginPage loginPage = new LoginPage();
			loginPage.WriteUser(login);
			loginPage.WritePassword(password);
			HomePage homepage = loginPage.ClickSubmit();
            return homepage;
        }

        public static bool IsLoggedIn()
        {
            HomePage homepage = new HomePage();
			return homepage.IsLogIn();
        }

        public static void LogOut()
        {
            HomePage homepage = new HomePage();
            homepage.LogoutHomePage();
            //	Assert.True(homepage.GetLoggedUsername().Contains(login));
            //	return (homepage.GetLoggedUsername().Equals(login));
        }

        public static AddProjectPage AddProject(string projectName, string projectIdentifier)
        {
			RedmineNavigation.GoTo<AddProjectPage>(Pages.NewProject);
			var newProject = new AddProjectPage();
			newProject.WriteName(projectName);
			newProject.WriteIdentifier(projectIdentifier);
			newProject.ClickCreate();
            return newProject;
        }

		public static AddIssuePage AddIssue(string projectName, string issueSubject, IssueType type = IssueType.Default, string issueDescription = "",
			IssueStatus status = IssueStatus.Default, IssuePriority priority = IssuePriority.Default)
		{
			RedmineNavigation.GoTo<AddIssuePage>(Pages.NewProject, projectName);
			var newIssue = new AddIssuePage();
			newIssue.ChooseType(type);
			newIssue.WriteSubject(issueSubject);
			newIssue.WriteDescription(issueDescription);
			newIssue.ChooseStatus(status);
			newIssue.ChoosePriority(priority);
			newIssue.ClickCreate();
			return newIssue;
		}
	}
}
