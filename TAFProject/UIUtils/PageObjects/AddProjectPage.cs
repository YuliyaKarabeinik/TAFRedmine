using OpenQA.Selenium;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class AddProjectPage : BasePage
    {
        static readonly By locatorInputProjectName = By.XPath("//input[@id='project_name']"),
            locatorInputProjectDescription = By.XPath("//textarea[@id='project_description']"),
            locatorInputProjectIdentifier = By.XPath("//input[@id='project_identifier']"),
            locatorInputHomepage = By.XPath("//input[@id='project_homepage']"),
            locatorCheckboxPublic = By.XPath("//input[@id='project_is_public']"),
            locatorComboboxSubOf = By.XPath("//select[@id='project_parent_id']"),
            locatorCheckboxInheritMembers = By.XPath("//input[@id='project_inherit_members']"),
            locatorButtonCreate = By.XPath("//input[@type='submit']"),
            locatorPositiveNotification = By.XPath("//*[@id='flash_notice']"),
            locatorNegativeNotification = By.XPath("//*[@id='errorExplanation']");

        BaseElement inputProjectName, inputProjectDescription, inputProjectIdentifier, inputHomepage,
            checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;
        BaseElement notificationAboutCreation;

        public AddProjectPage SetName(string projectName)
        {
            inputProjectName = SearchElementUtil.GetElement(locatorInputProjectName);
            inputProjectName.SendKeys(projectName);
            return this;
        }
        public AddProjectPage SetDescription(string projectDescription)
        {
            inputProjectDescription = SearchElementUtil.GetElement(locatorInputProjectDescription);
            inputProjectDescription.SendKeys(projectDescription);
            return this;
        }
        public AddProjectPage SetIdentifier(string projectIdentifier)
        {
            inputProjectIdentifier = SearchElementUtil.GetElement(locatorInputProjectIdentifier);
            inputProjectIdentifier.Clear();
            inputProjectIdentifier.SendKeys(projectIdentifier);
            return this;
        }

        public AddProjectPage SetHomepage(string homepage)
        {
            inputHomepage = SearchElementUtil.GetElement(locatorInputHomepage);
            inputHomepage.SendKeys(homepage);
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

        //where should use??
        public Enums.Notifications GetCreationResult()
        {
            if (IsSuccessfulCreation())
                return Enums.Notifications.Positive;
            notificationAboutCreation = SearchElementUtil.GetElement(locatorNegativeNotification);
            return Enums.Notifications.Negative;
        }

        public bool IsSuccessfulCreation()
        {
            notificationAboutCreation = SearchElementUtil.GetElement(locatorPositiveNotification);
            return notificationAboutCreation!=null&&notificationAboutCreation.Displayed;
        }
    }
}