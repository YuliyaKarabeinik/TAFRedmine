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
			LoginSteps.Login(user.UserName, user.Password);
		}

		
		static string projectIdentifier = "cs3m5cs3m";
		static string issueSubject = "subject".GetRandomString(5);

		[Test]
		public void AddIssuePositiveTest()
		{
			IssueSteps.AddIssue(projectIdentifier, issueSubject);
		}

	    [TearDown]
	    public void CloseTest()
	    {
		    browser.Close();
		    //Logging.Log.Info($"Test Login: {TestStatus}");
	    }
	}
}
