namespace Adilicious.Tests.Integration
{
    using System;

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

        public abstract void Navigate(int port);
    }
}