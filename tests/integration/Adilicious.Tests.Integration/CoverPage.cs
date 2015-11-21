namespace Adilicious.Tests.Integration
{
    using System;

    using OpenQA.Selenium;

    public class CoverPage : AdiliciousPage
    {
        public CoverPage(IWebDriver driver) : base(driver)
        {
        }

        public override void ClickPageLink()
        {
            Driver.FindElement(By.LinkText("Cover")).Click();
        }
    }
}