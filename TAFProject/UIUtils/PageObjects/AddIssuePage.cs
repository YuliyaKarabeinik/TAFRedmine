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
            locatorComboboxStatus = By.XPath("//select[@id='issue_status_id']"),
            locatorComboboxPriority = By.XPath("//select[@id='issue_priority_id']"),
            locatorButtonCreate = By.XPath("//input[@type='submit']");
        SelectElement comboboxIssueType, comboboxStatus, comboboxPriority;
        BaseElement textboxSubject, textboxDescription, buttonCreate;

        public AddIssuePage SelectType(IssueType type)
        {
            comboboxIssueType = new SelectElement(SearchElementUtil.GetElement(locatorComboboxIssueType));
            if (type != IssueType.Default)
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
        public AddIssuePage SelectStatus(IssueStatus status)
        {
            comboboxStatus = new SelectElement(SearchElementUtil.GetElement(locatorComboboxStatus));
            if (status != IssueStatus.Default)
                comboboxStatus.SelectByText(status.ToString().Replace(" ", ""));
            return this;
        }
        public AddIssuePage SelectPriority(IssuePriority priority)
        {
            comboboxPriority = new SelectElement(SearchElementUtil.GetElement(locatorComboboxPriority));
            if (priority != IssuePriority.Default)
                comboboxPriority.SelectByText(priority.ToString());
            return this;
        }
        public CreatedIssuePage ClickCreate()
        {
            buttonCreate = SearchElementUtil.GetElement(locatorButtonCreate);
            buttonCreate.Click();
            return new CreatedIssuePage();
        }
    }
}