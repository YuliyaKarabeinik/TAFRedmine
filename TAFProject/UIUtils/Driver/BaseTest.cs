using NUnit.Framework;
using TAFProject.Utils;

namespace TAFProject.UIUtils.Driver
{
    public class BaseTest
    {
        protected static Browser browser = Browser.Instance;
	    protected static Logger logger = Logger.Instance;
		[OneTimeSetUp]
        public void InitTest()
        {

	        logger.InitLogger();
	        logger.Log.Info($"Settings: " +
                             $"\nCurrent browser: {Configuration.Browser}" +
                             $"\nStart Url: {Configuration.StartUrl}" +
                             $"\nTimeout: {Configuration.ElementTimeout}");
            browser.WindowMaximise();
        }

        [OneTimeTearDown]
        public void CleanTest()
        {
            browser.Quit();
        }
    }
}
