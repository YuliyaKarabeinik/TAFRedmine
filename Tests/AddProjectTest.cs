using NUnit.Framework;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class AddProjectTest : BaseTest
    {
        private string login = "TAT18";
        private string password = "tat18pass";

        [SetUp]
        public void LogIn()
        {
            Steps.Login(login, password);
        }

        private string projectName = RandomGenerator.GetRandomString(5);
        private string projectIdentifier = RandomGenerator.GetRandomString(5);
        private string projectDescription = RandomGenerator.GetRandomString(5);
        private string homepage1 = RandomGenerator.GetRandomString(3);

        [Test]
        public void AddProject()
        {
            AddProjectPage addProjectPage = Steps.AddProject(projectName, projectIdentifier);
            Assert.IsTrue(addProjectPage.IsNotificationExist());
        }
    }
}
