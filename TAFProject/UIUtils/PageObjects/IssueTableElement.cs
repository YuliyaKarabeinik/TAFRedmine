using OpenQA.Selenium;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public enum Columns
	{
		Number, Tracker, Status, Priority, Subject, Asignee, Updated
	}
	class IssueTableElement : BaseElement
	{
		//IssuePage.Table[1]->issue
		//Table.Sort {return new issueTable;}

		static readonly string issueTableXPathLocator = "//div[@id='content']//table";
		BaseElement columnSortBy;

		public IWebElement this[int issueNumber] =>
			FindElement(By.XPath($"//tbody//tr[@id='issue-{issueNumber}']"));
		
		public IssueTableElement() : base(issueTableXPathLocator) { }
		
		public IssueTableElement SortBy(Columns column)
		{
			columnSortBy = column==Columns.Number ? FindColumn("#") : FindColumn(column.ToString());
			columnSortBy.Click();
			return new IssueTableElement();
		}

		public List<string> GetIssuesSubjectList()
		{
			List<string> subjectList = new List<string>();
			foreach (IWebElement subjectElement in FindElements(By.XPath("//tbody//td[@class='subject']")))//LINQ
			{
				subjectList.Add(subjectElement.Text);
			}
			return subjectList;
		}

	    private BaseElement FindColumn(string columnName)
	    {
	        return new BaseElement(FindElement(By.XPath($"//th[@title='Sort by \"{columnName}\"']")));
	    }
	}
}
