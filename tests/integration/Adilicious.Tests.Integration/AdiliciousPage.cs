namespace Adilicious.Tests.Integration
{
    using System;
    using System.Globalization;

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
    }
}