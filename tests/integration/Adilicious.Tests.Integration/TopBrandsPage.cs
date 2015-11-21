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

        public override IEnumerable<AdViewModel> GetDisplayedAds()
        {
            var rows = Driver.FindElements(By.XPath("//table/tbody/tr"));

            var ads =
                rows.Select(row => row.FindElements(By.TagName("td")))
                    .Select(
                        columns =>
                        new AdViewModel
                        {
                            NumPages = decimal.Parse(columns[0].Text),
                            BrandName = columns[1].Text
                        })
                    .ToList();

            return ads;
        }
    }
}