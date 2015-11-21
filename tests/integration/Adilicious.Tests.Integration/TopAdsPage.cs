namespace Adilicious.Tests.Integration
{
    using System;

    using OpenQA.Selenium;

    public class TopAdsPage : TopFivePage
    {
        public TopAdsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override void ClickPageLink()
        {
            Driver.FindElement(By.LinkText("Top Ads")).Click();
        }
    }
}