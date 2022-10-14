using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class OutlookLogin : BasePage
	{
		BaseElement userNameInput = new BaseElement(By.CssSelector("input[type='email']"));
		BaseElement passwdInput = new BaseElement(By.CssSelector("input[type='password']"));
		BaseElement nextButton = new BaseElement(By.Id("idSIButton9"));
		BaseElement noButton = new BaseElement(By.Id("idBtn_Back"));
		BaseElement wrongUserNameError = new BaseElement(By.CssSelector("#usernameError"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(nextButton);
		}

		public void Login(string userName, string passwd)
		{
			userNameInput.SendKeys(userName);
			nextButton.Click();
			passwdInput.SendKeys(passwd);
			nextButton.Click();
			noButton.Click();
		}

		public void EnterUserName(string userName)
		{
			userNameInput.SendKeys(userName);
		}

		public void EnterPasswd(string passwd)
		{
			passwdInput.SendKeys(passwd);
		}

		public void ClickNextButton()
		{
			nextButton.Click();
		}

		public void ClickNoButton()
		{
			noButton.Click();
		}

		public bool IsWrongUserNameErrorDisplayed()
		{
			return wrongUserNameError.WaitUntilDisplayed().Displayed;
		}

		public string getWrongUserNameErrorText()
		{
			return wrongUserNameError.WaitUntilDisplayed().Text;
		}
	}
}