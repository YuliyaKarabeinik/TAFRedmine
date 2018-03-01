using System.Configuration;

namespace TAFProject.Utils
{
	class Configuration
	{
		private static readonly string keyTimeout = "elementTimeout";
		private static readonly string keyBrowser = "browser";
		private static readonly string keyStartUrl = "startUrl";

		private static readonly string defaultTimeout = "5";
		private static readonly string defaultBrowser = "Chrome";
		private static readonly string defaultStartUrl = "http://icerow.com/";


		public static string ElementTimeout => GetConfigSettings(keyTimeout, defaultTimeout);
		
		public static string Browser => GetConfigSettings(keyBrowser, defaultBrowser);

		public static string StartUrl => GetConfigSettings(keyStartUrl, defaultStartUrl);
	
        private static string GetConfigSettings(string key, string defaultValue)
		{
			return ConfigurationManager.AppSettings[key] ?? defaultValue;
		}
	}
}
