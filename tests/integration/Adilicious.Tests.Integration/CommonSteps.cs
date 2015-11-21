namespace Adilicious.Tests.Integration
{
    using System;

    using OpenQA.Selenium.Firefox;

    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {
        private const int defaultPort = 1337;

        [BeforeFeature]
        public static void Setup()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var site = new AdiliciousWebsite(driver);
            site.Start(defaultPort);
            FeatureContext.Current.Set(site);
        }

        [AfterFeature]
        public static void Teardown()
        {
            FeatureContext.Current.Get<AdiliciousWebsite>().Stop();
        }

        [Given(@"I want to display (All|Cover|TopAds|TopBrands) ads")]
        public void GivenIWantToDisplayAds(AdDisplay display)
        {
            var page = FeatureContext.Current.Get<AdiliciousWebsite>().GetPage(display);
            page.Navigate(defaultPort);
            page.ClickPageLink();

            ScenarioContext.Current.Set(page);
            ScenarioContext.Current.Set("Brand Name");
        }
    }
}
