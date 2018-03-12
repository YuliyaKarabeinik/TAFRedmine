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
        protected Logger logger = new Logger();
        protected User user = new User();

        [OneTimeSetUp]
        public void InitTest()
        {
            browser.GoToUrl(Configuration.StartUrl);
            user.UserName = Configuration.User;
            user.Password = Configuration.Password;
            logger.InitLogger();
            logger.Log.Info("Settings: " +
                                 $"\nCurrent browser: {Configuration.Browser}" +
                                 $"\nStart Url: {Configuration.StartUrl}" +
                                 $"\nTimeout: {Configuration.ElementTimeout}");
            browser.WindowMaximise();
        }

        [OneTimeTearDown]
        public void CleanTest()
        {
            browser.Quit();
            logger.Log.Info("Exit from browser");
        }
    }
}
