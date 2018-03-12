using log4net;
using log4net.Config;

namespace TAFProject.Utils
{
	public class Logger : ILogger//add interface
	{
		//private static Logger _instance;
	//	public static Logger Instance => _instance ?? (_instance = new Logger());
		public ILog Log { get; } = LogManager.GetLogger("LOGGER");

		public void InitLogger()
		{
			XmlConfigurator.Configure();
		}
		public void Info(string information)
		{
			Log.Info(information);
		}
	}
}

