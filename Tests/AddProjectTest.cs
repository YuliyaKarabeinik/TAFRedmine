using NUnit.Framework;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddProjectTest : BaseTest
    {
        string login = "TAT18";
        string password = "tat18pass";

        [SetUp]
        public void LogIn()
        {
            browser.GoToUrl(Configuration.StartUrl);
            Steps.Login(login, password);
        }

	 //   private string prjName;

	    
	   
		static string name = "Name".GetRandomString(5);
        static string identifier = "Identifier".GetRandomString(5);
        static string incorrectIdentifier = "";

   
        [Test]
        public void AddProjectPositiveTest()
        {
			Steps.AddProject(name, identifier);
            Assert.IsTrue(Steps.IsProjectCreated());
        }

		[Test]
        public void AddProjectNegativeTest()
        {
            Steps.AddProject(name, incorrectIdentifier);
            Assert.IsFalse(Steps.IsProjectCreated());
        }

	    [TearDown]
	    public void CloseTest()
	    {
		    browser.Close();
	    }
	}
}
