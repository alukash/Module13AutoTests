using Module13AutoTests.Base;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Module13AutoTests.Pages
{
	internal class OutlookMailBox : BasePage
    {
		const string _emailAddress = "automationtestuser0@ya.ru";
		const string _emailSubject = "Module13";

		BaseElement newMessageButton = new BaseElement(By.CssSelector("button.root-174"));
		BaseElement unreadEmailItem = new BaseElement(By.CssSelector("div[aria-label~='Unread']"));
		BaseElement senderField = new BaseElement(By.CssSelector(".wide-content-host .allowTextSelection span"));
		BaseElement subjectField = new BaseElement(By.CssSelector("div[role='heading'].allowTextSelection span"));
		BaseElement sendButton = new BaseElement(By.CssSelector("button[name='Send']"));
		BaseElement toInput = new BaseElement(By.CssSelector("div[aria-label='To']"));
		BaseElement subjectInput = new BaseElement(By.CssSelector("input[aria-label='Add a subject']"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(newMessageButton, 30);
		}

		public void CreateNewMessage()
		{
			newMessageButton.Click();
			toInput.SendKeys(_emailAddress);
			toInput.SendKeys(Keys.Enter);
			subjectInput.SendKeys(_emailSubject);
			toInput.SendKeys(Keys.Enter);
			sendButton.Click();
		}

		internal void WaitForEmail()
		{
			int timeout = 5000;
			for (int i = 0; i < 10; i++)
			{
				if (unreadEmailItem.IsDisplayed())
				{
					return;
				}
				Thread.Sleep(timeout);
			}
			throw new ApplicationException("No email received");
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

		public bool IsNewMessageButtonDisplayed()
		{
			return newMessageButton.IsDisplayed();
		}



	}
}