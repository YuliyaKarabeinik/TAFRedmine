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
			//RedmineNavigation.GoToUrl("http://icerow.com/projects/new");
			var addProject = new AddProjectPage();
            Thread.Sleep(4000);
            addProject.CreateNewProject(projectName, projectIdentifier);
            Thread.Sleep(4000);
            //AddProjectPage addProjectPage = new AddProjectPage();
            return addProject;
        }
    }
}
