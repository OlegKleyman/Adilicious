namespace Adilicious.Tests.Integration
{
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Web.Models;

    using OpenQA.Selenium;

    public abstract class TopFivePage : AdiliciousPage
    {
        public TopFivePage(IWebDriver driver)
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
                            NumPages = decimal.Parse(columns[0].Text),
                            BrandName = columns[1].Text
                        })
                    .ToList();

            return ads;
        }
    }
}