using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public class LoginPage : BasePage
	{
		//public override string BaseUrl { get; protected set; }
		BaseElement loginForm, passwordForm, loginButton;

	    public LoginPage()
	    {
			//BaseUrl = "http://icerow.com/";
            loginForm = new BaseElement(By.Id("username"));
	        passwordForm = new BaseElement(By.Id("password"));
	        loginButton = new BaseElement("//input[@type='submit']");
        }

		public void InsertLogin(string login)
		{
			loginForm.SendKeys(login);
		}
		public void InsertPassword(string password)
		{
			passwordForm.SendKeys(password);
		}
		
		public HomePage ClickLoginButton()
		{
			loginButton.Click();
			return new HomePage();
		}
	}
}
