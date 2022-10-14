using Module13AutoTests.Base;
using Module13AutoTests.Pages;
using NUnit.Framework;

namespace Module13AutoTests.Steps
{
	internal class OutlookSteps
	{
		static OutlookStart startPage;
		static OutlookLogin loginPage;
		static OutlookMailBox mailBoxPage;

		public static void OpenStartPage()
		{
			Driver.GetDriver().Navigate().GoToUrl("https://www.outlook.com");
		}

		public static void Login(string userName, string passwd)
		{
			OpenStartPage();
			startPage = new OutlookStart();
			startPage.WaitPageLoaded();
			startPage.ClickSignInButtonButton();
			loginPage = new OutlookLogin();
			loginPage.WaitPageLoaded();
			loginPage.Login(userName, passwd);
			mailBoxPage = new OutlookMailBox();
			mailBoxPage.WaitPageLoaded();
		}

		public static void EnterUserName(string userName)
		{
			OpenStartPage();
			startPage = new OutlookStart();
			startPage.WaitPageLoaded();
			startPage.ClickSignInButtonButton();
			loginPage = new OutlookLogin();
			loginPage.WaitPageLoaded();
			loginPage.EnterUserName(userName);
			loginPage.ClickNextButton();
		}

		public static void CreateAndSendNewEmail(string address, string subject)
		{
			mailBoxPage = new OutlookMailBox();
			mailBoxPage.CreateNewMessage(address, subject);
			mailBoxPage.WaitPageLoaded();
		}

		public static void WaitForEmailReceived()
		{
			mailBoxPage = new OutlookMailBox();
			mailBoxPage.WaitPageLoaded();
			mailBoxPage.WaitForEmail();
		}

		public static void OpenUnreadEmail()
		{
			mailBoxPage = new OutlookMailBox();
			mailBoxPage.OpenUnreadEmail();
		}

		public static void VerifyEmailContent(string subject, string sender)
		{
			mailBoxPage = new OutlookMailBox();
			string subjectActual = mailBoxPage.GetSubject();
			Assert.AreEqual(subject, subjectActual, "Subject is not correct");
			string senderActual = mailBoxPage.GetSender();
			Assert.IsTrue(senderActual.Contains(sender), "Sender is not correct");
		}

		public static void VerifyLoginIsSucceess()
		{
			mailBoxPage = new OutlookMailBox();
			Assert.IsTrue(mailBoxPage.IsNewMessageButtonDisplayed(),
				"Failed to login - New Message button is not displayed");
		}

		public static void VerifyErrorIsDisplayed(string expectedError)
		{
			loginPage = new OutlookLogin();
			Assert.IsTrue(loginPage.IsWrongUserNameErrorDisplayed(),
				"Error message is not displayed");
			Assert.AreEqual(expectedError, loginPage.getWrongUserNameErrorText(),
				"Error message is not correct");
		}
	}
}