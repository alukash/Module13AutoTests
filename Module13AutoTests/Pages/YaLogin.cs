using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class YaLogin : BasePage
	{
		BaseElement userNameInput = new BaseElement(By.Id("passp-field-login"));
		BaseElement passwInput = new BaseElement(By.Id("passp-field-passwd"));
		BaseElement loginButton = new BaseElement(By.CssSelector("[id='passp:sign-in']"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(loginButton);
		}

		public void Login(string userName, string passwd)
		{
			userNameInput.SendKeys(userName);
			loginButton.Click();
			passwInput.SendKeys(passwd);
			loginButton.Click();
		}
	}
}