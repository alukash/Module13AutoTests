using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class YaLogin : BasePage
	{
		const string _userName = "automationtestuser0@ya.ru";
		const string _passw = "Autotest123";

		BaseElement userNameInput = new BaseElement(By.Id("passp-field-login"));
		BaseElement passwInput = new BaseElement(By.Id("passp-field-passwd"));
		BaseElement loginButton = new BaseElement(By.CssSelector("[id='passp:sign-in']"));

		public void waitPageLoaded()
		{
			WaitPageLoaded(loginButton);
		}

		public void Login()
		{
			userNameInput.SendKeys(_userName);
			loginButton.Click();
			passwInput.SendKeys(_passw);
			loginButton.Click();
		}
	}
}