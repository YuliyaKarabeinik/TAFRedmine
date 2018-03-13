using TAFProject.Models;

namespace TAFProject.UIUtils.Driver
{
	public class BrowserFactory
	{
		public static IBrowser GetBrowser(Enums.BrowserType type, int timeOutSec)
		{
			switch (type)
			{
				case Enums.BrowserType.Chrome:
					return new Chrome(timeOutSec);
				case Enums.BrowserType.Firefox:
					return new Firefox(timeOutSec);
				default:
					goto case Enums.BrowserType.Chrome;
			}
		}
	}
}
