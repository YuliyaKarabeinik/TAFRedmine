using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class AddProjectPage : BasePage
    {

        BaseElement inputProjectName, inputProjectDescription, inputProjectIdentifier,
            inputHomepage, checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;
        BaseElement notificationAboutCreation;

        public AddProjectPage()
        {
			inputProjectName = new BaseElement("//input[@id='project_name']");
            inputProjectDescription = new BaseElement("//textarea[@id='project_description']");
            inputProjectIdentifier = new BaseElement("//input[@id='project_identifier']");
            inputHomepage = new BaseElement("//input[@id='project_homepage']");
            checkboxPublic = new BaseElement("//input[@id='project_is_public']");
            comboboxSubOf = new BaseElement("//select[@id='project_parent_id']");
            checkboxInheritMembers = new BaseElement("//input[@id='project_inherit_members']");
            buttonCreate = new BaseElement("//input[@type='submit']");
        }


        public AddProjectPage CreateNewProject(string projectName, string projectIdentifier, string projectDescription = "", string homepage = "")
        {
            inputProjectName.SendKeys(projectName);
            inputProjectIdentifier.SendKeys(projectIdentifier);
            inputProjectDescription.SendKeys(projectDescription);
            inputHomepage.SendKeys(homepage);
            buttonCreate.Click();
            return this;
        }

        public bool IsNotificationExist()
        {
            notificationAboutCreation = new BaseElement("//div[@id='flash_notice']");
            if (notificationAboutCreation.Displayed)
                return true;
            else return false;
        }

    }
}
