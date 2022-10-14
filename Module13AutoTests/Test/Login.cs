using Module13AutoTests.Base;
using Module13AutoTests.Steps;
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
			const string passwd = "Autotest123";

			OutlookSteps.Login(userName, passwd);
			OutlookSteps.VerifyLoginIsSucceess();
		}

		[Test]
		public void InvalidLogin()
		{
			const string userName = "invalid_automationtestuser@outlook.com";
			const string expectedError = "That Microsoft account doesn't exist. Enter a different account or get a new one.";

			OutlookSteps.EnterUserName(userName);
			OutlookSteps.VerifyErrorIsDisplayed(expectedError);
		}

		[Test]
		public void EmptyLogin()
		{
			const string userName = "";
			const string expectedError = "Enter a valid email address, phone number, or Skype name.";

			OutlookSteps.EnterUserName(userName);
			OutlookSteps.VerifyErrorIsDisplayed(expectedError);
		}

		[TearDown]
		public void tearDown()
		{
			Driver.GetDriver().Quit();
		}
	}
}