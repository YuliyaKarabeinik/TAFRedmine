using NUnit.Framework;
using NUnit.Framework.Internal;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
    
        [SetUp]
        public void InitTest()
        {
			if (LoginSteps.IsLogIn())
                LoginSteps.LogOut();
	        logger.Info("Logout");
	        
		}
     
        [Test]
        public void CorrectLoginTest()
        {
	        logger.Info($"Test LogIn started with parameters:\n login: {user.UserName}, password {user.Password}");
			LoginSteps.Login(user.UserName, user.Password);
            Assert.True(LoginSteps.IsLogIn(user.UserName));
		}
	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Info($"Test finished with status: {TestExecutionContext.CurrentContext.CurrentResult.ResultState.Status}");
			browser.Close();
	    }
	}
}
