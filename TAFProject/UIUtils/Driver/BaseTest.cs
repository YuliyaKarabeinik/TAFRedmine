using NUnit.Framework;
using TAFProject.Utils;

namespace TAFProject.UIUtils.Driver
{
    public class BaseTest
    {
        protected static Browser browser = Browser.Instance;
        protected string login = "TAT18";
        protected string password = "tat18pass";

        [OneTimeSetUp]
        public void InitTest()
        {

			Logging.InitLogger(); // logger initialization
			Logging.Log.Info($"Settings: " +
							 $"\nCurrent browser: {Configuration.Browser}" +
							 $"\nStart Url: {Configuration.StartUrl}" +
							 $"\nTimeout: {Configuration.ElementTimeout}");
			System.Threading.Thread.Sleep(5);
			browser.WindowMaximise();
            browser.GoToUrl(Configuration.StartUrl);

            //	Steps.Login(login, password);
        }


        [OneTimeTearDown]
        public virtual void CleanTest()
        {
            browser.Quit();
        }
    }
}
