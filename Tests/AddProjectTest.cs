using NUnit.Framework;
using NUnit.Framework.Internal;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddProjectTest : BaseTest
    {

		static string projectName= "Name".GetRandomString(5);

	    private static string projectIdentifier = "ident".GetRandomString(5);
        static string incorrectIdentifier = "";

   
        [Test]
        public void AddProjectPositiveTest()
        {
	     	logger.Log.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
			Steps.AddProject(projectName, projectIdentifier);
	    	Assert.IsTrue(Steps.IsProjectCreated());
		}

		[Test]
        public void AddProjectNegativeTest()
        {
	        logger.Log.Info($"Test AddProject started with parameters:\n project name: {projectName}, identifier {projectIdentifier}");
			Steps.AddProject(projectName, incorrectIdentifier);
            Assert.IsFalse(Steps.IsProjectCreated());
        }

	    [TearDown]
	    public void CloseTest()
	    {
		    logger.Log.Info($"Test finished with status: {TestContext.CurrentContext.Result.Outcome}");
			browser.Close();
	    }
	}
}
