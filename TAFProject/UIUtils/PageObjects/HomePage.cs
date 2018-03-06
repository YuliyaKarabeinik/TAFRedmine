using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public class HomePage : BasePage
	{
	    readonly By loginIdentifierLocator = By.XPath("//*[@id='loggedas']//*[@class='user active']");
	    readonly By logoutLocator = By.XPath("//a[@class='logout']");
		BaseElement logout, loginIdentifier;

		public HomePage()
		{
			loginIdentifier = SearchElementUtil.GetElement(loginIdentifierLocator);
		}

		public string GetCurrentUser() => loginIdentifier.Text;

		public bool IsLogIn()
		{
			if (loginIdentifier == null)
				return false;
			return true;
		}

		public void LogoutHomePage()
		{
			logout = SearchElementUtil.GetElement(logoutLocator);
			logout.Click();
		}
	}
}
