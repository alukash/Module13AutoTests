using Module13AutoTests.Base;
using Module13AutoTests.Steps;
using NUnit.Framework;

namespace Module13AutoTests.Test
{
	public class SendEmailTests
	{
		[SetUp]
		public void Setup()
		{
			BaseTest.Setup();
		}

		[Test]
		public void SendEmail()
		{
			const string emailAddressOutlook = "automationtestuser1@outlook.com";
			const string emailAddressYa = "automationtestuser0@ya.ru";
			const string passwdOutlook = "Autotest123";
			const string passwdYa = "Autotest123";
			const string emailSubject = "Module13";

			OutlookSteps.Login(emailAddressOutlook, passwdOutlook);
			OutlookSteps.CreateAndSendNewEmail(emailAddressYa, emailSubject);

			YaSteps.Login(emailAddressYa, passwdYa);
			YaSteps.WaitForEmailReceived();
			YaSteps.OpenUnreadEmail();
			YaSteps.VerifyEmailContent(emailSubject, emailAddressOutlook);
			
			YaSteps.ReplyToEmail();
			YaSteps.VerifyEmailIsSent();

			OutlookSteps.OpenStartPage();
			OutlookSteps.WaitForEmailReceived();
			OutlookSteps.OpenUnreadEmail();
			OutlookSteps.VerifyEmailContent("Re: " + emailSubject, emailAddressYa);
		}

		[TearDown]
		public void TearDown()
		{
			BaseTest.TearDown();
		}
	}
}