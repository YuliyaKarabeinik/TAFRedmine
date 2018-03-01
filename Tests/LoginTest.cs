using System;
using System.Threading;
using NUnit.Framework;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace Tests
{
	[TestFixture]
	class LoginTest : BaseTest
	{
		[SetUp]
		public void InitTest()
		{
			if (Steps.IsLoggedIn(login, password))
				Steps.LogOut();
		}

		[Test]
		public void CorrectLoginTest()
		{
			HomePage homepage = Steps.Login(login, password);
			Assert.True(homepage.GetLoggedUsername().Contains(login));
			//	Logging.Log.Info($"Test Login: {TestStatus}");
		}
	}

}
