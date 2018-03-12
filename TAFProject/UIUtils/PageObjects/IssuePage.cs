using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFProject.UIUtils.PageObjects
{
    class IssuePage: BasePage
    {
        static readonly string issueTableXPathLocator = "//div[@id='content']//table";
        private IssueTable table;

    }
}
