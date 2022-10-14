using Module13AutoTests.Base;
using OpenQA.Selenium;
using Polly;
using System;
using System.Threading;

namespace Module13AutoTests.Pages
{
	internal class YaMailBox : BasePage
	{
		BaseElement newMessageButton = new BaseElement(By.CssSelector("a[href='#compose']"));
		BaseElement refreshButton = new BaseElement(By.CssSelector("button.qa-LeftColumn-SyncButton"));
		BaseElement unreadEmailItem = new BaseElement(By.CssSelector("div.mail-MessagesList a.is-unread"));
		BaseElement senderField = new BaseElement(By.CssSelector("span.qa-MessageViewer-SenderEmail"));
		BaseElement subjectField = new BaseElement(By.CssSelector("h1.qa-MessageViewer-Title-text"));
		BaseElement replyButton = new BaseElement(By.CssSelector("div.qa-QuickReplyPlaceholder"));
		BaseElement sendButton = new BaseElement(By.CssSelector("div.ComposeSendButton button"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(newMessageButton);
		}

		//internal void WaitForEmail()
		//{
		//	int timeout = 5000;
		//	for (int i = 0; i < 10; i++)
		//	{
		//		if (unreadEmailItem.IsDisplayed())
		//		{
		//			return;
		//		}
		//		Thread.Sleep(timeout);
		//		refreshButton.Click();
		//	}
		//	throw new ApplicationException("No email received");
		//}

		internal void WaitForEmail()
		{
			Policy
				.Handle<ApplicationException>()
				.WaitAndRetry(retryCount: 10, sleepDuration => TimeSpan.FromSeconds(5))
				.Execute(() =>
				{
					if (!unreadEmailItem.IsDisplayed())
					{
						refreshButton.Click();
						throw new ApplicationException("No email received");
					}
				});
		}

		internal void OpenUnreadEmail()
		{
			unreadEmailItem.Click();
		}

		public string GetSender()
		{
			return senderField.GetText();
		}

		public string GetSubject()
		{
			return subjectField.GetText();
		}

		public void ReplyEmail()
		{
			replyButton.Click();
		}

		public void SendEmail()
		{
			sendButton.Click();
			sendButton.WaitUntilNotDisplayed();
		}

		public bool IsSendButtonDisplayed()
		{
			return sendButton.IsDisplayed();
		}
	}
}