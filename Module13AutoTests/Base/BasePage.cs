using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Module13AutoTests.Base
{
    internal class BasePage
    {
        const int _defaultTimeout = 10;
        public IWebDriver driver = Driver.GetDriver();

        internal void WaitPageLoaded(BaseElement element)
        {
            WaitPageLoaded(element, _defaultTimeout);
        }

        internal void WaitPageLoaded(BaseElement element, int timeout)
        {
            element.WaitUntilDisplayed(timeout);
        }

        internal void WaitPageLoaded(string title)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_defaultTimeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(condition =>
            {
                return driver.Title.Equals(title);
            });
        }
    }
}