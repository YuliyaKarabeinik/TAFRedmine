using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class LoginPage : BasePage
    {
        By textboxUserLocator = By.Id("username");
		By textboxPasswordLocator = By.Id("password");
		By loginButtonLocator = By.XPath("//input[@type='submit']");
		BaseElement textboxUser, textboxPassword, loginButton;

		public LoginPage()
        {
			textboxUser = SearchElementUtil.GetElement(textboxUserLocator);
			textboxPassword = SearchElementUtil.GetElement(textboxPasswordLocator);
            loginButton = SearchElementUtil.GetElement(loginButtonLocator);
        }

		public void WriteUser(string login)
		{
			textboxUser.SendKeys(login);
		}

		public void WritePassword(string password)
		{
			textboxPassword.SendKeys(password);
		}

		public HomePage ClickSubmit()
		{
			loginButton.Click();
			return new HomePage();
		}
    }
}
