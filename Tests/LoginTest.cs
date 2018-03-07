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
        public void InitialTest()
        {
			logger.Log.Info("Test LogIn started");
            browser.GoToUrl(Configuration.StartUrl);
            if (Steps.IsLogIn())
                Steps.LogOut();
	        var res = TestContext.CurrentContext.Result;
	        logger.Log.Info($"Test finished with status: {res}");
        }

        [TearDown]
        public void CloseTest()
        {
            browser.Close();
         }

        [Test]
        public void CorrectLoginTest()
        {
            Steps.Login(user, password);
            Assert.True(Steps.IsLogIn(user));
        }
    }
}
