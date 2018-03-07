using NUnit.Framework;
using TAFProject.Utils;

namespace TAFProject.UIUtils.Driver
{
    public class BaseTest
    {
        protected static Browser browser = Browser.Instance;

        [OneTimeSetUp]
        public void InitTest()
        {
            Logging.InitLogger();
            Logging.Log.Info($"Settings: " +
                             $"\nCurrent browser: {Configuration.Browser}" +
                             $"\nStart Url: {Configuration.StartUrl}" +
                             $"\nTimeout: {Configuration.ElementTimeout}");
            browser.WindowMaximise();
            browser.GoToUrl(Configuration.StartUrl);//setup
        }

        [OneTimeTearDown]
        public void CleanTest()
        {
            browser.Quit();
        }
    }
}
