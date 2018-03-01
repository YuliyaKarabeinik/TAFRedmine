using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
	public static class Steps
	{
		static	Navigation navigation = new Navigation();

		public static HomePage Login(string login, string password)
		{
			LoginPage loginPage = new LoginPage();
			HomePage homepage = loginPage.Login(login, password);
			return homepage;
		}

		public static bool IsLoggedIn(string login, string password)
		{
			try
			{
				HomePage homepage = new HomePage();
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;

			}
		}

		public static  void LogOut()
		{
			HomePage homepage = new HomePage();
			homepage.LogoutHomePage();
			//	Assert.True(homepage.GetLoggedUsername().Contains(login));
		//	return (homepage.GetLoggedUsername().Equals(login));
		}
	
		public static AddProjectPage AddProject(string projectName, string projectIdentifier)
		{
			
			navigation.GoToUrl(navigation.AddProjectUrl);
			var addProject = new AddProjectPage();
			Thread.Sleep(4000);
			addProject.CreateNewProject(projectName, projectIdentifier);
			Thread.Sleep(4000);
			//AddProjectPage addProjectPage = new AddProjectPage();
			return addProject;
		}
	}
}
