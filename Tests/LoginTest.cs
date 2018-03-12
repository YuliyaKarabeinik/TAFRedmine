using NUnit.Framework;
using NUnit.Framework.Internal;
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
			if (Steps.IsLogIn())
                Steps.LogOut();
	        logger.Log.Info("Logout");
		}
     
        [Test]
        public void CorrectLoginTest()
        {
			logger.Log.Info($"Test LogIn started with parameters:\n login: {user.UserName}, password {user.Password}");
			Steps.Login(user.UserName, user.Password);
            Assert.True(Steps.IsLogIn(user.UserName));
		}
	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Log.Info($"Test finished with status: {TestExecutionContext.CurrentContext.CurrentResult.ResultState.Status}");
			browser.Close();
	    }
	}
}
