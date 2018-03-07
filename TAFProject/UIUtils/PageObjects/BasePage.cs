using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public abstract class BasePage
    {
        protected Browser browser = Browser.Instance;
        protected BasePage()
        {
            new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(browser.ImpWait)).
                Until(driver => driver.FindElement(By.XPath("//title")));//WaitElement
        }
    }
}
