using Module13AutoTests.Base;
using Module13AutoTests.Pages;
using NUnit.Framework;

namespace Module13AutoTests.Test
{
	public class SendEmailTests
	{
		const string _emailAddressOutlook = "automationtestuser1@outlook.com";
		const string _emailAddressYa = "automationtestuser0@ya.ru";
		const string _emailSubject = "Module13";

		[SetUp]
		public void Setup()
		{
			Driver.CreateDriver().Manage().Window.Maximize();
		}

		[Test]
		public void SendEmail()
		{
			//Login to Outlook
			OutlookLogin outlookLoginPage = new OutlookLogin();
			outlookLoginPage.Open();
			outlookLoginPage.Login();
			OutlookMailBox outlookMailBoxPage = new OutlookMailBox();
			outlookMailBoxPage.WaitPageLoaded();

			//Send new email
			outlookMailBoxPage.CreateNewMessage();
			outlookMailBoxPage.WaitPageLoaded();

			//Login to Ya
			YaHome yaHomePage = new YaHome();
			yaHomePage.Open();
			yaHomePage.ClickSignInButton();
			YaLogin yaLoginPage = new YaLogin();
			yaLoginPage.Login();

			//wait for email received
			YaMailBox yaMailBoxPage = new YaMailBox();
			yaMailBoxPage.WaitPageLoaded();
			yaMailBoxPage.WaitForEmail();
			yaMailBoxPage.OpenUnreadEmail();

			//check email content
			string subject = yaMailBoxPage.GetSubject();
			Assert.AreEqual(_emailSubject, subject, "Subject is not correct");
			string sender = yaMailBoxPage.GetSender();
			Assert.AreEqual(_emailAddressOutlook, sender, "Sender is not correct");

			//reply to email
			yaMailBoxPage.ReplyEmail();
			Assert.IsTrue(yaMailBoxPage.SendEmail(), "Failed to reply email");

			//go to Outlook
			Driver.GetDriver().Navigate().GoToUrl("https://www.outlook.com");

			//wait for email received
			outlookMailBoxPage.WaitPageLoaded();
			outlookMailBoxPage.WaitForEmail();

			//check email content
			outlookMailBoxPage.OpenUnreadEmail();
			subject = outlookMailBoxPage.GetSubject();
			Assert.AreEqual("Re: " + _emailSubject, subject, "Subject is not correct");
			sender = outlookMailBoxPage.GetSender();
			Assert.IsTrue(sender.Contains(_emailAddressYa), "Sender is not correct");
		}

		[TearDown]
		public void tearDown()
		{
			Driver.GetDriver().Quit();
		}
	}
}