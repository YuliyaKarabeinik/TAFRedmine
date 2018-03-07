using TAFProject.Models;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
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
            RedmineNavigation.GoTo<AddProjectPage>(Pages.NewProject);
            var newProject = new AddProjectPage();
            newProject.SetName(projectName);
            newProject.SetIdentifier(projectIdentifier);
            newProject.ClickCreate();
        }

        public static bool IsProjectCreated(out string notificationText)
        {
            AddProjectPage page = new AddProjectPage();
            notificationText = page.GetNotificationAboutCreationText();
            return page.IsSuccessfulCreation();
        }

        public static bool IsProjectCreated()
        {
            AddProjectPage page = new AddProjectPage();
            return page.IsSuccessfulCreation();
        }

        public static void AddIssue(string projectIdentifier, string issueSubject, Enums.IssueType type = Enums.IssueType.Default, string issueDescription = "",
            Enums.IssueStatus status = Enums.IssueStatus.Default, Enums.IssuePriority priority = Enums.IssuePriority.Default)
        {
            RedmineNavigation.GoTo<AddIssuePage>(Pages.NewIssue, projectIdentifier);
            var newIssue = new AddIssuePage();
            newIssue.SelectType(type);
            newIssue.SetSubject(issueSubject);
            newIssue.SetDescription(issueDescription);
            newIssue.SelectStatus(status);
            newIssue.SelectPriority(priority);
            newIssue.ClickCreate();
        }
    }
}
