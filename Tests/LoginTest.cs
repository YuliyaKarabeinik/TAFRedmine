using NUnit.Framework;
using NUnit.Framework.Internal;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
    
        [SetUp]
        public void InitTest()
        {
			browser = BrowserFactory.GetBrowser(Enums.BrowserType.Chrome, Configuration.ElementTimeout);
			browser.GoToUrl(Configuration.StartUrl);
			if (LoginSteps.IsLogIn(browser))
                LoginSteps.LogOut(browser);
	        logger.Info("Logout");
	        
		}
     
        [Test]
        public void CorrectLoginTest()
        {
	        logger.Info($"Test LogIn started with parameters:\n login: {user.UserName}, password {user.Password}");
			LoginSteps.Login(browser, user.UserName, user.Password);
            Assert.True(LoginSteps.IsLogIn(browser, user.UserName));
		}
	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Info($"Test finished with status: {TestExecutionContext.CurrentContext.CurrentResult.ResultState.Status}");
			browser.Close();
	    }
	}
}
