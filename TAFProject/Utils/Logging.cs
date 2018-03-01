using log4net;
using log4net.Config;

namespace TAFProject.Utils
{
	public static class Logging//add interface
	{
		private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log => log;

		public static void InitLogger()
		{
			XmlConfigurator.Configure();
		}
	}
}

