using Module13AutoTests.Base;
using OpenQA.Selenium;
using System.Threading;

namespace Module13AutoTests.Pages
{
    internal class YaHome : BasePage
    {
		BaseElement signInButton = new BaseElement(By.CssSelector("div.PSHeader-Right button"));

		public void Open()
        {
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl("https://mail.yandex.ru/");
			WaitPageLoaded(signInButton);
        }

        public void ClickSignInButton()
        {
			signInButton.Click();
        }
    }
}