namespace Adilicious.Tests.Integration
{
    using System;
    using System.Globalization;

    using OpenQA.Selenium;

    public class DisplayAllPage : AdiliciousPage
    {
        public DisplayAllPage(IWebDriver driver) : base(driver)
        {
            
        }

        public override void Navigate(int port)
        {
            Driver.Navigate().GoToUrl(String.Format(CultureInfo.InvariantCulture, "http://localhost:{0}/home/all", port));
        }
    }
}