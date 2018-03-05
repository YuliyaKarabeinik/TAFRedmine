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
		protected string login = "TAT18";
		protected string password = "tat18pass";

		[SetUp]
        public void InitialTest()
        {
			if (Steps.IsLoggedIn())
                Steps.LogOut();
        }

		[TearDown]
		public void CloseTest()
		{
			browser.Close();
		}

		[Test]
        public void CorrectLoginTest()
        {
			HomePage homepage = Steps.Login(login, password);
            Assert.True(homepage.GetCurrentUser()==login);
            //Logging.Log.Info($"Test Login: {TestStatus}");
        }
    }

}
