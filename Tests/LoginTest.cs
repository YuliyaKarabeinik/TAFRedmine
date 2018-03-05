using NUnit.Framework;
using System.Threading;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
        [SetUp]
        public void InitialTest()
        {
			if (Steps.IsLoggedIn())
                Steps.LogOut();
        }

        [Test]
        public void CorrectLoginTest()
        {
			HomePage homepage = Steps.Login(login, password);
			Thread.Sleep(5);
            Assert.True(homepage.GetCurrentUser()==login);
            //	Logging.Log.Info($"Test Login: {TestStatus}");
        }
    }

}
