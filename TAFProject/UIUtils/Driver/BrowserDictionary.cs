using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFProject.UIUtils.Driver
{
	public static class BrowserDictionary
	{
		public static ConcurrentDictionary<string, Browser> browsers=new ConcurrentDictionary<string, Browser>();

	}
}
