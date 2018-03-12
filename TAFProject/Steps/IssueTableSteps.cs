using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFProject.Models;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Steps
{
	public static class IssueTableSteps
	{

		public static void IssueTable()
		{
			IssuePage page = new IssuePage();
			Issue issue = page.Table[1];
		}
	}
}
