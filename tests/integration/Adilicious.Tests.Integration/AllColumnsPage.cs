namespace Adilicious.Tests.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core;
    using Adilicious.Web.Models;

    using OpenQA.Selenium;

    public abstract class AllColumnsPage : AdiliciousPage
    {
        public AllColumnsPage(IWebDriver driver)
            : base(driver)
        {
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
                                AdId = int.Parse(columns[0].Text),
                                BrandId = int.Parse(columns[1].Text),
                                BrandName = columns[2].Text,
                                NumPages = decimal.Parse(columns[3].Text),
                                Position = (Position)Enum.Parse(typeof(Position), columns[4].Text, true)
                            })
                    .ToList();

            return ads;
        }
    }
}