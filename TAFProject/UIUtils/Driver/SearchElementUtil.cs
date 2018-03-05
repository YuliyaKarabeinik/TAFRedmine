using OpenQA.Selenium;

namespace TAFProject.UIUtils.Driver
{
	class SearchElementUtil
	{
		Browser browser = Browser.Instance;
		public static BaseElement GetElement (By locator)
		{
			try
			{
				BaseElement element = new BaseElement(locator);
				return element;
			}
			catch (NoSuchElementException)
			{
				return null;
			}			
		}

		public static BaseElement GetElement(string xPathLocator)
		{
			try
			{
				BaseElement element = new BaseElement(xPathLocator);
				return element;
			}
			catch (NoSuchElementException)
			{
				return null;
			}
		}
		//public void WaitElement(By locator)
		//{
		
		//}
	}
}
