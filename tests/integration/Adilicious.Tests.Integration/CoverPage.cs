namespace Adilicious.Tests.Integration
{
    using System;
    using System.Collections.Generic;

    using Adilicious.Web.Models;

    using OpenQA.Selenium;

    public class CoverPage : AllColumnsPage
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