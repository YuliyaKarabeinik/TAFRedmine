using NUnit.Framework;
using TAFProject.Steps;
using TAFProject.Utils;
using TAFProject.UIUtils.Driver;
using TAFProject.Models;

namespace Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AddIssueTest : BaseTest
    {
		[SetUp]
		public void LogIn()
		{
			browser = BrowserFactory.GetBrowser(Enums.BrowserType.Chrome, Configuration.ElementTimeout);
			browser.GoToUrl(Configuration.StartUrl);
			LoginSteps.Login(browser, user.UserName, user.Password);
		}

		
		static string projectIdentifier = "cs3m5cs3m";
		static string issueSubject = "subject".GetRandomString(5);

		[Test]
		public void AddIssuePositiveTest()
		{
			IssueSteps.AddIssue(browser, projectIdentifier, issueSubject);
			Assert.IsTrue(IssueSteps.IsIssueCreated(browser, projectIdentifier, issueSubject));
		}

		[TearDown]
	    public void CloseTest()
	    {
		    browser.Close();
		    //Logging.Log.Info($"Test Login: {TestStatus}");
	    }
	}
}
