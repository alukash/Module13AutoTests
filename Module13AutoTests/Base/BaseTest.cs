namespace Module13AutoTests.Base
{
	internal class BaseTest
	{
		public static void Setup()
		{
			Driver.CreateDriver().Manage().Window.Maximize();
		}

		public static void TearDown()
		{
			Driver.GetDriver().Quit();
		}
	}
}
