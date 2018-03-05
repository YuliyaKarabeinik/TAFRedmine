using OpenQA.Selenium;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class AddProjectPage : BasePage
    {
		Dictionary<string, By> locators = new Dictionary<string, By>()
		{
			{ "name", By.XPath("//input[@id='project_name']") },
			{ "description", By.XPath("//textarea[@id='project_description']") },
			{ "identifier", By.XPath("//input[@id='project_identifier']") },
			{ "homepage", By.XPath("//input[@id='project_homepage']") },
			{ "public", By.XPath("//input[@id='project_is_public']") },
			{ "subprojectOf", By.XPath("//select[@id='project_parent_id']") },
			{ "inheritMembers", By.XPath("//input[@id='project_inherit_members']") },
			{ "buttonCreate", By.XPath("//input[@type='submit']") }
		};
        BaseElement inputProjectName, inputProjectDescription, inputProjectIdentifier,
            inputHomepage, checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;
        BaseElement notificationAboutCreation;

        public AddProjectPage()
        {
			inputProjectName = SearchElementUtil.GetElement(locators["name"]);
            inputProjectDescription = SearchElementUtil.GetElement(locators["description"]);
            inputProjectIdentifier = SearchElementUtil.GetElement(locators["identifier"]);
            inputHomepage = SearchElementUtil.GetElement(locators["homepage"]);
            checkboxPublic = SearchElementUtil.GetElement(locators["public"]);
            comboboxSubOf = SearchElementUtil.GetElement(locators["subprojectOf"]);
            checkboxInheritMembers = SearchElementUtil.GetElement(locators["inheritMembers"]);
            buttonCreate = SearchElementUtil.GetElement(locators["buttonCreate"]);
        }

		public void WriteName(string projectName)
		{
			inputProjectName.SendKeys(projectName);
		}
		public void WriteDescription(string projectDescription)
		{
			inputProjectDescription.SendKeys(projectDescription);
		}
		public void WriteIdentifier(string projectIdentifier)
		{
			inputProjectIdentifier.SendKeys(projectIdentifier);
		}
		public void WriteHomepage(string homepage)
		{
			inputHomepage.SendKeys(homepage);
		}
		public AddProjectPage ClickCreate()
		{
			buttonCreate.Click();
			return this;
		}

		public bool IsNotificationExist()
        {
            notificationAboutCreation = new BaseElement("//div[@id='flash_notice']");
            if (notificationAboutCreation.Displayed)
                return true;
            return false;
        }
    }
}
