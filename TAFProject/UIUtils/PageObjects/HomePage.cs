using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class HomePage : BasePage
    {
        public override string BaseUrl { get; protected set; }

        BaseElement logout;
        BaseElement loginIdentifier;

        public HomePage()
        {
            //  BaseUrl = "http://icerow.com/";
            loginIdentifier = new BaseElement(By.Id("loggedas"));
        }
        /*
                try
                {
                    driver.FindElement(by);
                    return true;
                }
            catch (NoSuchElementException)
            {
            return false;
        }*/
        public string GetLoggedUsername() => loginIdentifier.Text;
        public bool IsLogIn()
        {
            if (loginIdentifier.Displayed)
                return true;
            else return false;
        }

        public void LogoutHomePage()
        {
            logout = new BaseElement("//a[@class='logout']");
            logout.Click();
        }
        //public override void GoToPage()
        //{
        //	browser.GoToUrl(BASE_URL);
        //}

    }
}
