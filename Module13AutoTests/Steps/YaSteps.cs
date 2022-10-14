using Module13AutoTests.Base;
using Module13AutoTests.Pages;
using NUnit.Framework;
using System.Threading;

namespace Module13AutoTests.Steps
{
	internal class YaSteps
	{
		static YaHome yaHomePage;
		static YaLogin yaLoginPage;
		static YaMailBox yaMailBoxPage;

		public static void OpenHomePage()
		{
			Thread.Sleep(5000);
			Driver.GetDriver().Navigate().GoToUrl("https://mail.yandex.ru/");
			yaHomePage = new YaHome();
			yaHomePage.WaitPageLoaded();
			yaHomePage.ClickSignInButton();
		}

		public static void Login(string userName, string passwd)
		{
			OpenHomePage();
			yaLoginPage = new YaLogin();
			yaLoginPage.Login(userName, passwd);
		}

		public static void WaitForEmailReceived()
		{
			yaMailBoxPage = new YaMailBox();
			yaMailBoxPage.WaitPageLoaded();
			yaMailBoxPage.WaitForEmail();
		}

		public static void OpenUnreadEmail()
		{
			yaMailBoxPage = new YaMailBox();
			yaMailBoxPage.OpenUnreadEmail();
		}

		public static void ReplyToEmail()
		{
			yaMailBoxPage = new YaMailBox();
			yaMailBoxPage.ReplyEmail();
			yaMailBoxPage.SendEmail();
		}

		public static void VerifyEmailContent(string subject, string sender)
		{
			yaMailBoxPage = new YaMailBox();
			string subjectActual = yaMailBoxPage.GetSubject();
			Assert.AreEqual(subject, subjectActual, "Subject is not correct");
			string senderActual = yaMailBoxPage.GetSender();
			Assert.AreEqual(sender, senderActual, "Sender is not correct");
		}

		public static void VerifyEmailIsSent()
		{
			yaMailBoxPage = new YaMailBox();
			Assert.IsFalse(yaMailBoxPage.IsSendButtonDisplayed(), "Failed to send email");
		}
	}
}
