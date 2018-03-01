using System;
using OpenQA.Selenium;
using TAFProject.Utils;

namespace TAFProject.UIUtils.Driver
{
    public class Browser
    {
        static Browser _instance;
        BrowserFactory.BrowserType browserTypeFromConfig;
        private int impWait;
        public int ImpWait
        {
            get
            {
                return impWait;
            }
        }
        public IWebDriver Driver { get; private set; }

        private Browser()
        {
            int.TryParse(Configuration.ElementTimeout, out impWait);
            Enum.TryParse(Configuration.Browser, out browserTypeFromConfig);
            Driver = BrowserFactory.GetDriver(browserTypeFromConfig, impWait);
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

        public void Quit()
        {
            Driver.Quit();
            _instance = null;
            Driver = null;
        }
    }
}
