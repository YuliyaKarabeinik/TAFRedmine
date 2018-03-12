using NUnit.Framework;
using TAFProject.Steps;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddIssueTest : BaseTest
    {
		[SetUp]
		public void LogIn()
		{
			browser.GoToUrl(Configuration.StartUrl);
			Steps.Login(user.UserName, user.Password);
		}

		[TearDown]
		public void CloseTest()
		{
			browser.Close();
			//Logging.Log.Info($"Test Login: {TestStatus}");
		}
		static string projectIdentifier = "cs3m5cs3m";
		static string issueSubject = "subject".GetRandomString(5);

		[Test]
		public void AddIssuePositiveTest()
		{
			Steps.AddIssue(projectIdentifier, issueSubject);
		}
	}
}
