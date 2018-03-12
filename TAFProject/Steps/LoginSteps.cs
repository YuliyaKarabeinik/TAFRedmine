using TAFProject.Models;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
    public static class LoginSteps
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
		
    }
}
