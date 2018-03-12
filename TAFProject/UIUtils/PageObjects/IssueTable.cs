using OpenQA.Selenium;
using System.Collections.Generic;
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

        static readonly string issueTableXPathLocator = "//div[@id='content']//table";
        private IWebElement table;
        Browser browser = Browser.Instance;
        BaseElement columnSortBy;

        //корректировка!
        public Issue this[int issueNumber]
        {
            get
            {
                browser.FindElement(By.XPath($"//tbody//tr[@id='issue-{issueNumber}']"));
                return new Issue();//заполнение!
            }

        }

        public IssueTable()
        {

        }

        public IssueTable SortBy(Columns column)
        {
            columnSortBy = column == Columns.Number ? FindColumn("#") : FindColumn(column.ToString());
            columnSortBy.Click();
            return new IssueTable();
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
