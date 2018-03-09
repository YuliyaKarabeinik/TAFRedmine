using OpenQA.Selenium;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class AddProjectPage : BasePage
    {
        static readonly By locatorTextboxProjectName = By.XPath("//input[@id='project_name']"),
            locatorTextboxProjectDescription = By.XPath("//textarea[@id='project_description']"),
            locatorTextboxProjectIdentifier = By.XPath("//input[@id='project_identifier']"),
            locatorTextboxHomepage = By.XPath("//input[@id='project_homepage']"),
            locatorCheckboxPublic = By.XPath("//input[@id='project_is_public']"),
            locatorComboboxSubOf = By.XPath("//select[@id='project_parent_id']"),
            locatorCheckboxInheritMembers = By.XPath("//input[@id='project_inherit_members']"),
            locatorButtonCreate = By.XPath("//input[@type='submit']"),
            locatorPositiveNotification = By.XPath("//*[@id='flash_notice']"),
            locatorNegativeNotification = By.XPath("//*[@id='errorExplanation']");

        BaseElement textboxProjectName, textboxProjectDescription, textboxProjectIdentifier, textboxHomepage,
            checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;

        BaseElement notificationAboutCreation;

        public AddProjectPage SetName(string projectName)
        {
            textboxProjectName = SearchElementUtil.GetElement(locatorTextboxProjectName);
            textboxProjectName.SendKeys(projectName);
            return this;
        }
        public AddProjectPage SetDescription(string projectDescription)
        {
            textboxProjectDescription = SearchElementUtil.GetElement(locatorTextboxProjectDescription);
            textboxProjectDescription.SendKeys(projectDescription);
            return this;
        }
        public AddProjectPage SetIdentifier(string projectIdentifier)
        {
            textboxProjectIdentifier = SearchElementUtil.GetElement(locatorTextboxProjectIdentifier);
            textboxProjectIdentifier.Clear();
            textboxProjectIdentifier.SendKeys(projectIdentifier);
            return this;
        }

        public AddProjectPage SetHomepage(string homepage)
        {
            textboxHomepage = SearchElementUtil.GetElement(locatorTextboxHomepage);
            textboxHomepage.SendKeys(homepage);
            return this;
        }

        public AddProjectPage SelectPublic(bool tickParam = true)
        {
            checkboxPublic = SearchElementUtil.GetElement(locatorCheckboxPublic);
            if (tickParam)
                checkboxPublic.Check();
            else
                checkboxPublic.Uncheck();
            return this;
        }

        public AddProjectPage SelectInheritMembers(bool tickParam = true)
        {
            checkboxInheritMembers = SearchElementUtil.GetElement(locatorCheckboxInheritMembers);
            if (tickParam)
                checkboxInheritMembers.Check();
            else
                checkboxInheritMembers.Uncheck();
            return this;
        }

        public AddProjectPage ClickCreate()
        {
            buttonCreate = SearchElementUtil.GetElement(locatorButtonCreate);
            buttonCreate.Click();
            return this;
        }

        public string GetNotificationAboutCreationText()
        {
            if (!IsSuccessfulCreation())
                notificationAboutCreation = SearchElementUtil.GetElement(locatorNegativeNotification);
            return notificationAboutCreation.Text;
        }

       
        public bool IsSuccessfulCreation()
        {
            notificationAboutCreation = SearchElementUtil.GetElement(locatorPositiveNotification);
            return notificationAboutCreation!=null && notificationAboutCreation.Displayed;
        }

	    //where should use??
		public Enums.Notifications GetCreationResult()
	    {
		    if (IsSuccessfulCreation())
			    return Enums.Notifications.Positive;
		    notificationAboutCreation = SearchElementUtil.GetElement(locatorNegativeNotification);
		    return Enums.Notifications.Negative;
	    }

	}
}