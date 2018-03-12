using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
	public static class ProjectSteps
	{
		public static void AddProject(string projectName, string projectIdentifier)
		{
			var newProject = RedmineNavigation.GoTo<NewProjectPage>(Pages.NewProject);
			newProject.SetName(projectName);
			newProject.SetIdentifier(projectIdentifier);
			newProject.ClickCreate();
		}

		public static bool IsProjectCreated()
		{
			NewProjectPage page = new NewProjectPage();
			return page.IsSuccessfulCreation();
		}

		public static bool IsProjectCreated(out string notificationText)
		{
			NewProjectPage page = new NewProjectPage();
			notificationText = page.GetNotificationAboutCreationText();
			return page.IsSuccessfulCreation();
		}
	}
}
