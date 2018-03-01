using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
	public abstract class BasePage
	{
	    public abstract string BaseUrl { get; protected set; }
        protected Browser browser = Browser.Instance;
		//public abstract void GoToPage();
	}
}
