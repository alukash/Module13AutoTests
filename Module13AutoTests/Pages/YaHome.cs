using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class YaHome : BasePage
	{
		BaseElement signInButton = new BaseElement(By.CssSelector("div.PSHeader-Right button"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(signInButton);
		}

		public void ClickSignInButton()
		{
			signInButton.Click();
		}
	}
}