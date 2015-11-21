namespace Adilicious.Tests.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Adilicious.Web.Models;

    using OpenQA.Selenium;

    public abstract class AdiliciousPage
    {
        protected IWebDriver Driver { get; set; }

        protected AdiliciousPage(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            Driver = driver;
        }

        public abstract void ClickPageLink();

        public void Navigate(int port)
        {
            Driver.Navigate().GoToUrl(String.Format(CultureInfo.InvariantCulture, "http://localhost:{0}/home", port));
        }

        public IEnumerable<AdViewModel> GetDisplayedAds()
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
                                Position = columns[4].Text
                            })
                    .ToList();

            return ads;
        }
    }
}