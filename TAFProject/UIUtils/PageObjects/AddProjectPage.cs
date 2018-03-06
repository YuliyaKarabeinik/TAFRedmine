﻿using OpenQA.Selenium;
using System.Collections.Generic;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public class AddProjectPage : BasePage
	{
		Dictionary<string, By> locators = new Dictionary<string, By>()
		{
			{ "name", By.XPath("//input[@id='project_name']") },
			{ "description", By.XPath("//textarea[@id='project_description']") },
			{ "identifier", By.XPath("//input[@id='project_identifier']") },
			{ "homepage", By.XPath("//input[@id='project_homepage']") },
			{ "public", By.XPath("//input[@id='project_is_public']") },
			{ "subprojectOf", By.XPath("//select[@id='project_parent_id']") },
			{ "inheritMembers", By.XPath("//input[@id='project_inherit_members']") },
			{ "buttonCreate", By.XPath("//input[@type='submit']") },
			{ "positiveNotification", By.XPath("//*[@id='flash_notice']") },
			{ "negativeNotification", By.XPath("//*[@id='errorExplanation']") }
		};
		BaseElement inputProjectName, inputProjectDescription, inputProjectIdentifier,
			inputHomepage, checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;
		BaseElement notificationAboutCreation;

		public void WriteName(string projectName)
		{
			inputProjectName = SearchElementUtil.GetElement(locators["name"]);
			inputProjectName.SendKeys(projectName);
		}
		public void WriteDescription(string projectDescription)
		{
			inputProjectDescription = SearchElementUtil.GetElement(locators["description"]);
			inputProjectDescription.SendKeys(projectDescription);
		}
		public void WriteIdentifier(string projectIdentifier)
		{
			inputProjectIdentifier = SearchElementUtil.GetElement(locators["identifier"]);
			inputProjectIdentifier.Clear();
			inputProjectIdentifier.SendKeys(projectIdentifier);
		}
		public void WriteHomepage(string homepage)
		{
			inputHomepage = SearchElementUtil.GetElement(locators["homepage"]);
			inputHomepage.SendKeys(homepage);
		}
		public void CheckPublic()
		{
			checkboxPublic = SearchElementUtil.GetElement(locators["public"]);
			Check(checkboxPublic);
		}
		public void UncheckPublic()
		{
			checkboxPublic = SearchElementUtil.GetElement(locators["public"]);
			Uncheck(checkboxPublic);
		}
		public void CheckInheritMembers()
		{
			checkboxInheritMembers = SearchElementUtil.GetElement(locators["inheritMembers"]);
			Check(checkboxInheritMembers);
		}
		public void UncheckInheritMembers()
		{
			checkboxInheritMembers = SearchElementUtil.GetElement(locators["inheritMembers"]);
			Uncheck(checkboxInheritMembers);
		}
		public AddProjectPage ClickCreate()
		{
			buttonCreate = SearchElementUtil.GetElement(locators["buttonCreate"]);
			buttonCreate.Click();
			return this;
		}

		public bool IsPositiveNotificationAppear()
		{
			notificationAboutCreation = SearchElementUtil.GetElement(locators["positiveNotification"]);
			if (notificationAboutCreation.Displayed)
				return true;
			return false;
		}

		public bool IsNegativeNotificationAppear()
		{
			notificationAboutCreation = SearchElementUtil.GetElement(locators["negativeNotification"]);
			if (notificationAboutCreation.Displayed)
				return true;
			return false;
		}

		private void Check(BaseElement element)
		{
			if (!element.Selected)
				element.Click();
		}

		private void Uncheck(BaseElement element)
		{
			if (element.Selected)
				element.Click();
		}
	}
}
