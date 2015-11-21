namespace Adilicious.Tests.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core;
    using Adilicious.Web.Models;

    using OpenQA.Selenium;

    public class TopBrandsPage : TopFivePage
    {
        public TopBrandsPage(IWebDriver driver)
            : base(driver)
        {
           
        }

        public override void ClickPageLink()
        {
            Driver.FindElement(By.LinkText("Top Brands")).Click();
        }
    }
}