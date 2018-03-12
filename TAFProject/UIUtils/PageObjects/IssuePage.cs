using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TAFProject.UIUtils.PageObjects
{
    class IssuePage: BasePage
    {
        static readonly string issueTableXPathLocator = "//div[@id='content']//table";

        public IssueTable Table => new IssueTable(By.XPath(issueTableXPathLocator));

    }
}
