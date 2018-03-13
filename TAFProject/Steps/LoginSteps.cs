using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Steps
{
    public static class LoginSteps
    {
        public static void Login(IBrowser browser, string login, string password)
        {
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.SetUser(login);
            loginPage.SetPassword(password);
            loginPage.ClickSubmit();
            //RedmineNavigation.GoTo<HomePage>(browser, Pages.Home);
        }

        public static bool IsLogIn(IBrowser browser, string user = "")
        {
            HomePage homepage = new HomePage(browser.Driver);
            if (user == string.Empty)
                return homepage.IsLogIn();

            return homepage.GetCurrentUser() == user;
        }

        public static void LogOut(IBrowser browser)
        {
            HomePage homepage = new HomePage(browser.Driver);
            homepage.LogoutHomePage();
        }
		
    }
}
