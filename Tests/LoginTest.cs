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
            browser.GoToUrl(Configuration.StartUrl);
            if (Steps.IsLogIn())
                Steps.LogOut();
        }

        [TearDown]
        public void CloseTest()
        {
            browser.Close();
            //Logging.Log.Info($"Test Login: {TestStatus}");
        }

        [Test]
        public void CorrectLoginTest()
        {
            Steps.Login(user, password);
            Assert.True(Steps.IsLogIn(user));
        }
    }
}
