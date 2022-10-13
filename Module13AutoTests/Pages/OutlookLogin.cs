using Module13AutoTests.Base;
using OpenQA.Selenium;

namespace Module13AutoTests.Pages
{
	internal class OutlookLogin : BasePage
	{
		const string _userName = "automationtestuser1@outlook.com";
		const string _passw = "Autotest123";

		BaseElement userNameInput = new BaseElement(By.CssSelector("input[type='email']"));
		BaseElement passwdInput = new BaseElement(By.CssSelector("input[type='password']"));
		BaseElement signInButton = new BaseElement(By.LinkText("Sign in"));
		BaseElement nextButton = new BaseElement(By.Id("idSIButton9"));
		BaseElement noButton = new BaseElement(By.Id("idBtn_Back"));
		BaseElement wrongUserNameError = new BaseElement(By.CssSelector("#usernameError"));

		public void Open()
		{
			driver.Navigate().GoToUrl("https://www.outlook.com");
			WaitPageLoaded(signInButton);
			signInButton.Click();
			WaitPageLoaded(nextButton);
		}

		public void Login()
		{
			userNameInput.SendKeys(_userName);
			nextButton.Click();
			passwdInput.SendKeys(_passw);
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