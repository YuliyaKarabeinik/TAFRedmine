using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class LoginPage : BasePage
    {
        static readonly By locatorTextboxUser = By.Id("username"),
						locatorTextboxPassword = By.Id("password"),
						locatorButtonLogin = By.XPath("//input[@type='submit']");
        BaseElement textboxUser, textboxPassword, buttonLogin;

		public LoginPage() { }
		public LoginPage(IWebDriver driver) : base(driver){ }

		public LoginPage SetUser(string login)
        {
            textboxUser = (BaseElement)SearchElementUtil.GetElement(driver, locatorTextboxUser);
            textboxUser.SendKeys(login);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            textboxPassword = (BaseElement)SearchElementUtil.GetElement(driver, locatorTextboxPassword);
            textboxPassword.SendKeys(password);
            return this;
        }

        public HomePage ClickSubmit()
        {
            buttonLogin = (BaseElement)SearchElementUtil.GetElement(driver, locatorButtonLogin);
            buttonLogin.Click();
            return new HomePage(driver);
        }
    }
}