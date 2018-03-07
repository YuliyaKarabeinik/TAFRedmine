using OpenQA.Selenium;
using TAFProject.Utils;

namespace TAFProject.UIUtils.Driver
{
    public class Browser
    {
        static Browser _instance;
        BrowserType browserTypeFromConfig;
        public int ImpWait { get; }
        public IWebDriver Driver { get; private set; }

        private Browser()
        {
            ImpWait = Configuration.ElementTimeout;//не должно быть обращения к Config!
            browserTypeFromConfig = Configuration.Browser;
            Driver = BrowserFactory.GetDriver(browserTypeFromConfig, ImpWait);
        }

        public static Browser Instance => _instance ?? (_instance = new Browser());

        public void WindowMaximise()
        {
            Driver.Manage().Window.Maximize();
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public void Close()
        {
            Driver.Close();
        }

        public void Quit()
        {
            Driver.Quit();
            _instance = null;
            Driver = null;
        }
    }
}
