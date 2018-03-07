using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class AddIssuePage : BasePage
    {
        static readonly By locatorComboboxIssueType = By.XPath("//select[@id='issue_tracker_id']"),
            locatorTextboxSubject = By.XPath("//input[@id='issue_subject']"),
            locatorTextboxDescription = By.XPath("//textarea[@id='issue_description']"),
            locatorComboboxStatus = By.XPath("//input[@id='project_homepage']"),
            locatorComboboxPriority = By.XPath("//input[@id='project_is_public']"),
            locatorButtonCreate = By.XPath("//select[@id='project_parent_id']");
        SelectElement comboboxIssueType, comboboxStatus, comboboxPriority;
        BaseElement textboxSubject, textboxDescription, buttonCreate;

        public AddIssuePage SelectType(Enums.IssueType type)
        {
            comboboxIssueType = new SelectElement(SearchElementUtil.GetElement(locatorComboboxIssueType));
            if (type != Enums.IssueType.Default)
                comboboxIssueType.SelectByText(type.ToString().Replace(" ", ""));
            return this;
        }
        public AddIssuePage SetSubject(string issueSubject)
        {
            textboxSubject = SearchElementUtil.GetElement(locatorTextboxSubject);
            textboxSubject.SendKeys(issueSubject);
            return this;
        }
        public AddIssuePage SetDescription(string issueDescription)
        {
            textboxDescription = SearchElementUtil.GetElement(locatorTextboxDescription);
            textboxDescription.SendKeys(issueDescription);
            return this;
        }
        public AddIssuePage SelectStatus(Enums.IssueStatus status)
        {
            comboboxStatus = new SelectElement(SearchElementUtil.GetElement(locatorComboboxStatus));
            if (status != Enums.IssueStatus.Default)
                comboboxStatus.SelectByText(status.ToString().Replace(" ", ""));
            return this;
        }
        public AddIssuePage SelectPriority(Enums.IssuePriority priority)
        {
            comboboxPriority = new SelectElement(SearchElementUtil.GetElement(locatorComboboxPriority));
            if (priority != Enums.IssuePriority.Default)
                comboboxPriority.SelectByText(priority.ToString());
            return this;
        }
        public void ClickCreate()
        {
            buttonCreate = SearchElementUtil.GetElement(locatorButtonCreate);
            buttonCreate.Click();
        }
    }
}