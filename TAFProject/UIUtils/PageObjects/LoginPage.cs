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

		public void WriteUser(string login)
		{
			textboxUser = SearchElementUtil.GetElement(textboxUserLocator);
			textboxUser.SendKeys(login);
		}

		public void WritePassword(string password)
		{
			textboxPassword = SearchElementUtil.GetElement(textboxPasswordLocator);
			textboxPassword.SendKeys(password);
		}

		public HomePage ClickSubmit()
		{
			loginButton = SearchElementUtil.GetElement(loginButtonLocator);
			loginButton.Click();
			return new HomePage();
		}
	}
}
