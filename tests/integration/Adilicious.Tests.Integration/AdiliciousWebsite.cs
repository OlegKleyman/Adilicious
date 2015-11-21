namespace Adilicious.Tests.Integration
{
    using System;
    using System.Globalization;
    using System.IO;

    using IISExpressAutomation;

    using OpenQA.Selenium;

    public class AdiliciousWebsite
    {
        private readonly IWebDriver driver;

        private IISExpress iis;

        public AdiliciousWebsite(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Start(int port)
        {
            if (iis != null)
            {
                throw new InvalidDataException("IIS Express is already running");
            }

            iis = new IISExpress(new Parameters
            {
                Path = Path.GetFullPath(@"..\..\..\..\..\src\Adilicious.Web"),
                Port = port
            });

        }

        public void Stop()
        {
            iis.Dispose();
            iis = null;
            driver.Quit();
        }

        public AdiliciousPage GetPage(AdDisplay display)
        {
            AdiliciousPage page;

            switch (display)
            {
                case AdDisplay.All:
                    page = new DisplayAllPage(driver);
                    break;
                case AdDisplay.Cover:
                    page = new CoverPage(driver);
                    break;
                default:
                    throw new InvalidOperationException(
                        String.Format(CultureInfo.InvariantCulture, "Invalid display: {0}", display));
            }

            return page;
        }
    }
}