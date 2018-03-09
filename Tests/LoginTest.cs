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
			logger.Log.Info($"Test LogIn started with parameters:\n login: {user}, password {password}");
			Steps.Login(user, password);
            Assert.True(Steps.IsLogIn(user));
		}
	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Log.Info($"Test finished with status: {TestExecutionContext.CurrentContext.CurrentResult.ResultState.Status}");
			browser.Close();
	    }
	}
}
