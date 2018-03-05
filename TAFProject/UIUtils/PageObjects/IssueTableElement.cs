using OpenQA.Selenium;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    class IssueTableElement : BaseElement
    {
        static readonly string issueTableXPathLocator = "//div[@id='content']//table";
        BaseElement sortByNumber, sortByTracker, sortByStatus, sortByPriority, sortBySubject,
            sortByAssignee, sortByUpdated;

        public IssueTableElement() : base(issueTableXPathLocator) { }

        public void SortBySubject()
        {
            sortBySubject = new BaseElement(FindElement(By.XPath("//th[@title='Sort by \"Subject\"']")));
            sortBySubject.Click();
        }

        public List<string> GetIssuesSubjectList()
        {
            List<string> subjectList = new List<string>();
            foreach (IWebElement subjectElement in FindElements(By.XPath("//tbody//td[@class='subject']")))
            {
                subjectList.Add(subjectElement.Text);
            }
            return subjectList;
        }
    }
}
