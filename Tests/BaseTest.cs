using NUnit.Framework;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    public class BaseTest
    {
		protected IBrowser browser;
        protected ILogger logger = new Logger();
        protected User user = new User();

        [OneTimeSetUp]
        public void InitOnce()
        {
            user.UserName = Configuration.User;
            user.Password = Configuration.Password;
            logger.InitLogger();
            logger.Info("Settings: " +
                                 $"\nCurrent browser: {Configuration.Browser}" +
                                 $"\nStart Url: {Configuration.StartUrl}" +
                                 $"\nTimeout: {Configuration.ElementTimeout}");            
        }
		
	    [OneTimeTearDown]
        public void CleanTest()
        {
            logger.Info("Exit from browser");
        }
    }
}
