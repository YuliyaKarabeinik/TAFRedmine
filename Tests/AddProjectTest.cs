using NUnit.Framework;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AddProjectTest : BaseTest
    {

		static string projectName= "Name".GetRandomString(5);

	    private static string projectIdentifier = "ident".GetRandomString(5);
        static string incorrectIdentifier = "";

        [SetUp]
        public void LogIn()
        {
			browser = BrowserFactory.GetBrowser(Enums.BrowserType.Chrome, Configuration.ElementTimeout);
			browser.GoToUrl(Configuration.StartUrl);
            LoginSteps.Login(browser, user.UserName, user.Password);//было, что 2 логина записали в 1 браузер. Как избежать?
        }

		[Test]
		public void AddProjectPositiveTest()
        {
	     	logger.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
			ProjectSteps.AddProject(browser, projectName, projectIdentifier);
	    	Assert.IsTrue(ProjectSteps.IsProjectCreated(browser));
		}

		[Test]
		public void AddProjectNegativeTest()
        {
	        logger.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
	        ProjectSteps.AddProject(browser, projectName, incorrectIdentifier);
            Assert.IsFalse(ProjectSteps.IsProjectCreated(browser));
        }

	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Info($"Test finished with status: {TestContext.CurrentContext.Result.Outcome}");
			browser.Close();
	    }
	}
}
