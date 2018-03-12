using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Web.Query.Dynamic;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public enum Columns
    {
        Number, Tracker, Status, Priority, Subject, Asignee, Updated
    }

    class IssueTable
    {
        //IssuePage.Table[1]->issue
        //Table.Sort {return new issueTable;}

        //static readonly string issueTableXPathLocator = "//div[@id='content']//table";
        //private IWebElement table;
        
        Browser browser = Browser.Instance;
        static readonly string templateIssueFromTableLocator = "//tbody//tr[@id='issue-{0}']";
        readonly By locator;
        
        BaseElement columnSortBy;

        public Issue this[int issueNumber]
        {
            get
            {
                IWebElement tableRow = browser.FindElement(By.XPath(string.Format(templateIssueFromTableLocator, issueNumber)));
                return new Issue
                {
                    //Number = int.Parse(tableRow.FindElement(By.XPath("//td[@class='id']")).Text),
                    Type = (IssueType) Enum.Parse(typeof(IssueType),
                        tableRow.FindElement(By.XPath("//td[@class='tracker']")).Text),
                    Status = (IssueStatus) Enum.Parse(typeof(IssueStatus),
                        tableRow.FindElement(By.XPath("//td[@class='status']")).Text),
                    Priority = (IssuePriority) Enum.Parse(typeof(IssuePriority),
                        tableRow.FindElement(By.XPath("//td[@class='priority']")).Text),
                    Subject = tableRow.FindElement(By.XPath("//td[@class='subject']")).Text
                };
            }
        }

        public IssueTable(By locator)
        {
            this.locator = locator;
            //table = browser.FindElement(locator);
        }

        public IssueTable SortBy(Columns column)
        {
            columnSortBy = column == Columns.Number ? FindColumn("#") : FindColumn(column.ToString());
            columnSortBy.Click();
            return new IssueTable(locator);
        }

        public List<string> GetListOf(Columns column)
        {
            List<string> list = new List<string>();
            foreach (IWebElement subjectElement in browser.Driver.FindElements(By.XPath($"//tbody//td[@class='{column.ToString().ToLower()}']")))//LINQ   //для # подходит??
            {
                list.Add(subjectElement.Text);
            }
            return list;
        }

        private BaseElement FindColumn(string columnName)
        {
            return new BaseElement(browser.FindElement(By.XPath($"//th[@title='Sort by \"{columnName}\"']")));
        }
        
    }
}
