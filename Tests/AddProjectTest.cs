using NUnit.Framework;
using TAFProject.Steps;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddProjectTest : BaseTest
    {

		static string projectName= "Name".GetRandomString(5);

	    private static string projectIdentifier = "ident".GetRandomString(5);
        static string incorrectIdentifier = "";

        [SetUp]
        public void LogIn()
        {
            browser.GoToUrl(Configuration.StartUrl);
            LoginSteps.Login(user.UserName, user.Password);
        }

        [Test]
        public void AddProjectPositiveTest()
        {
	     	logger.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
			ProjectSteps.AddProject(projectName, projectIdentifier);
	    	Assert.IsTrue(ProjectSteps.IsProjectCreated());
		}

		[Test]
        public void AddProjectNegativeTest()
        {
	        logger.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
	        ProjectSteps.AddProject(projectName, incorrectIdentifier);
            Assert.IsFalse(ProjectSteps.IsProjectCreated());
        }

	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Info($"Test finished with status: {TestContext.CurrentContext.Result.Outcome}");
			browser.Close();
	    }
	}
}
