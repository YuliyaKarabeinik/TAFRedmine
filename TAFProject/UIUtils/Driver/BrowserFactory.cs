using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TAFProject.UIUtils.Driver
{
	static class BrowserFactory
	{
		const int defaultTimeout = 5;
		public enum BrowserType
		{
			Chrome,
			Firefox
		}

		public static IWebDriver GetDriver(BrowserType type, int timeOutSec = defaultTimeout)
		{
			IWebDriver driver;
			timeOutSec = IsCorrectTimeout(timeOutSec) ? timeOutSec : defaultTimeout;
			switch (type)
			{
				case BrowserType.Chrome:
				{
					var service = ChromeDriverService.CreateDefaultService();//?path to driver.exe
					ChromeOptions options = new ChromeOptions();
					options.AddArgument("disable-infobars");//hiding warning window
					//driver = new ChromeDriver();
					driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
					break;
				}

				case BrowserType.Firefox:
				{
					var service = FirefoxDriverService.CreateDefaultService();
					var options = new FirefoxOptions();
					options.AddArgument("disable-infobars");//hiding warning window
					//driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
					driver = new FirefoxDriver();
					break;
				}
				default:
					goto case BrowserType.Chrome;

			}
			return driver;
		}

		private static bool IsCorrectTimeout(int timeOutSec) => timeOutSec > 0;
	}
}
