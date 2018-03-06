using System;
using System.Configuration;

namespace TAFProject.Utils
{
	public enum BrowserType
	{
		Chrome,
		Firefox
	}
	static class Configuration
	{
		private const string KeyTimeout = "elementTimeout";
		private const string KeyBrowser = "browser";
		private const string KeyStartUrl = "startUrl";

		private static readonly int defaultTimeout = 10;
		private static readonly BrowserType defaultBrowser = BrowserType.Chrome;
		private static readonly string defaultStartUrl = "http://icerow.com/";


		public static int ElementTimeout
		{
			get
			{
				int.TryParse(GetConfigSettings(KeyTimeout, defaultTimeout.ToString()), out int timeout);
				if (IsCorrectTimeout(timeout))
					return timeout;
				return defaultTimeout;
			}
		}

		public static BrowserType Browser
		{
			get
			{
				if (Enum.TryParse(GetConfigSettings(KeyBrowser, defaultBrowser.ToString()),
					out BrowserType browserTypeFromConfig))
					return browserTypeFromConfig;
				return defaultBrowser;
			}
		}

		public static string StartUrl => GetConfigSettings(KeyStartUrl, defaultStartUrl);

		private static string GetConfigSettings(string key, string defaultValue)
		{
			return ConfigurationManager.AppSettings[key] ?? defaultValue;
		}

		private static bool IsCorrectTimeout(int timeOutSec) => timeOutSec > 0;
	}
}
