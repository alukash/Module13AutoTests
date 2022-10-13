using OpenQA.Selenium.Chrome;

namespace Module13AutoTests.Base
{
	internal class Driver
	{
		static ChromeDriver _chromeDriver;

		public static ChromeDriver GetDriver()
		{
			return _chromeDriver;
		}

		public static ChromeDriver CreateDriver()
		{
			_chromeDriver = new ChromeDriver();
			return _chromeDriver;
		}
	}
}