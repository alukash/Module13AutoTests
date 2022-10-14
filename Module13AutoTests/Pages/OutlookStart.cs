using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class OutlookStart : BasePage
	{
		BaseElement signInButton = new BaseElement(By.LinkText("Sign in"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(signInButton);
		}

		public void ClickSignInButtonButton()
		{
			signInButton.Click();
		}
	}
}