using Module13AutoTests.Base;
using Module13AutoTests.Pages;
using NUnit.Framework;

namespace Module13AutoTests.Test
{
	public class LoginTests
	{
		[SetUp]
		public void Setup()
		{
			Driver.CreateDriver().Manage().Window.Maximize();
		}

		[Test]
		public void ValidLogin()
		{
			const string userName = "automationtestuser1@outlook.com";
			const string passw = "Autotest123";

			OutlookLogin outlookLoginPage = new OutlookLogin();
			outlookLoginPage.Open();
			outlookLoginPage.EnterUserName(userName);
			outlookLoginPage.ClickNextButton();
			outlookLoginPage.EnterPasswd(passw);
			outlookLoginPage.ClickNextButton();
			outlookLoginPage.ClickNoButton();
			OutlookMailBox outlookMailBoxPage = new OutlookMailBox();
			outlookMailBoxPage.WaitPageLoaded();
			Assert.IsTrue(outlookMailBoxPage.IsNewMessageButtonDisplayed(), "Failed to login - New Message button is not displayed");
		}

		[Test]
		public void InvalidLogin()
		{
			const string userName = "invalid_automationtestuser@outlook.com";
			const string expectedError = "That Microsoft account doesn't exist. Enter a different account or get a new one.";

			OutlookLogin outlookLoginPage = new OutlookLogin();
			outlookLoginPage.Open();
			outlookLoginPage.EnterUserName(userName);
			outlookLoginPage.ClickNextButton();
			Assert.IsTrue(outlookLoginPage.IsWrongUserNameErrorDisplayed(), "Error message is not displayed");
			Assert.AreEqual(expectedError, outlookLoginPage.getWrongUserNameErrorText(), "Error message is not correct");
		}

		[Test]
		public void EmptyLogin()
		{
			const string userName = "";
			const string expectedError = "Enter a valid email address, phone number, or Skype name.";

			OutlookLogin outlookLoginPage = new OutlookLogin();
			outlookLoginPage.Open();
			outlookLoginPage.EnterUserName(userName);
			outlookLoginPage.ClickNextButton();
			Assert.IsTrue(outlookLoginPage.IsWrongUserNameErrorDisplayed(), "Error message is not displayed");
			Assert.AreEqual(expectedError, outlookLoginPage.getWrongUserNameErrorText(), "Error message is not correct");
		}

		[TearDown]
		public void tearDown()
		{
			Driver.GetDriver().Quit();
		}
	}
}