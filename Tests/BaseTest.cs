using System;
using NUnit.Framework;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    public class BaseTest
    {
        protected static Browser browser = Browser.Instance;
        //protected static Logger logger = Logger.Instance;
        protected ILogger logger = new Logger();
        protected User user = new User();

        [OneTimeSetUp]
        public void InitTest()
        {
            browser.GoToUrl(Configuration.StartUrl);
            user.UserName = Configuration.User;
            user.Password = Configuration.Password;
            logger.InitLogger();
            logger.Info("Settings: " +
                                 $"\nCurrent browser: {Configuration.Browser}" +
                                 $"\nStart Url: {Configuration.StartUrl}" +
                                 $"\nTimeout: {Configuration.ElementTimeout}");
            browser.WindowMaximise();
        }

	    //[SetUp]
	    //public void SetUp()
	    //{
		   // var browser1 = new ChromeDriver();
		   // BrowserDictionary.browsers.TryAdd(TestContext.CurrentContext.Test.Name, browser1);
		   // BrowserDictionary.browsers.TryGetValue(TestContext.CurrentContext.Test.Name, out driver);

	    //}

	    [OneTimeTearDown]
        public void CleanTest()
        {
            browser.Quit();
            logger.Info("Exit from browser");
        }
		//[AttributeUsage(AttributeTargets.Method)]
    }
}
