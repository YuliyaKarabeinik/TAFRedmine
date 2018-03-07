using System.Runtime.InteropServices;
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

        [TearDown]
        public void CloseTest()
        {
            browser.Close();
            //Logging.Log.Info($"Test Login: {TestStatus}");
        }
        static string name = RandomGenerator.GetRandomString(5);
        static string identifier = RandomGenerator.GetRandomString(5);
        static string incorrectIdentifier = "";

        //static object[] incorrectProjectFields = {
        //	new object [] {RandomGenerator.GetRandomString(5), ""}
        //};

        [Test]
        public void AddProjectPositiveTest()
        {
            Steps.AddProject(name, identifier);
            Assert.IsTrue(Steps.IsProjectCreated());
        }

        //[Test, TestCaseSource("incorrectProjectFields")]
        [Test]
        public void AddProjectNegativeTest()
        {
            Steps.AddProject(name, incorrectIdentifier);
            Assert.IsFalse(Steps.IsProjectCreated());
        }
    }
}
