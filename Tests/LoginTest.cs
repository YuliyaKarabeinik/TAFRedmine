using NUnit.Framework;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
        string user = "TAT18";
        string password = "tat18pass";

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
	       // logger.InitLogger();
	        logger.Log.Info("Test LogIn started");
			Steps.Login(user, password);
            Assert.True(Steps.IsLogIn(user));

	        //var res = TestContext.CurrentContext.Result;
	        //logger.Log.Info($"Test finished with status: {res}");
		}
	    [TearDown]
	    public void CloseTest()
	    {
		    browser.Close();
	    }
	}
}
