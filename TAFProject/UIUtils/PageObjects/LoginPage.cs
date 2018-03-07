using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class LoginPage : BasePage
    {
        static readonly By locatorInputUser = By.Id("username"),
            locatorInputPassword = By.Id("password"),
            locatorButtonLogin = By.XPath("//input[@type='submit']");
        BaseElement inputUser, inputPassword, buttonLogin;

        public LoginPage SetUser(string login)
        {
            inputUser = SearchElementUtil.GetElement(locatorInputUser);
            inputUser.SendKeys(login);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            inputPassword = SearchElementUtil.GetElement(locatorInputPassword);
            inputPassword.SendKeys(password);
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