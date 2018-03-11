using NUnit.Framework;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddIssueTest : BaseTest
    {
		string login = "TAT18";
		string password = "tat18pass";

		[SetUp]
		public void LogIn()
		{
			browser.GoToUrl(Configuration.StartUrl);
			Steps.Login(login, password);
		}

		[TearDown]
		public void CloseTest()
		{
			browser.Close();
			//Logging.Log.Info($"Test Login: {TestStatus}");
		}
		static string projectIdentifier = "cs3m5cs3m";
		static string issueSubject = RandomGenerator.GetRandomString(5);

		[Test]
		public void AddIssuePositiveTest()
		{
			Steps.AddIssue(projectIdentifier, issueSubject);
		}
	}
}
