using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class HomePage : BasePage
    {
		By loginIdentifierLocator = By.Id("loggedas");
		By logoutLocator = By.XPath("//a[@class='logout']");
		BaseElement logout, loginIdentifier;

        public HomePage()
        {
            loginIdentifier = new BaseElement(loginIdentifierLocator);
        }
       
        public string GetLoggedUsername() => loginIdentifier.Text;
        public bool IsLogIn()
        {
            if (loginIdentifier.Displayed)
                return true;
            else return false;
        }

        public void LogoutHomePage()
        {
            logout = new BaseElement(logoutLocator);
            logout.Click();
        }
    }
}
