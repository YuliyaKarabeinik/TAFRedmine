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

        public LoginPage SetUser(string login)
        {
            textboxUser = SearchElementUtil.GetElement(locatorTextboxUser);
            textboxUser.SendKeys(login);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            textboxPassword = SearchElementUtil.GetElement(locatorTextboxPassword);
            textboxPassword.SendKeys(password);
            return this;
        }

        public HomePage ClickSubmit()
        {
            buttonLogin = SearchElementUtil.GetElement(locatorButtonLogin);
            buttonLogin.Click();
            return new HomePage();
        }
    }
}