﻿namespace Adilicious.Tests.Integration
{
    using OpenQA.Selenium.Firefox;

    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {
        private const int defaultPort = 1337;

        [BeforeFeature]
        public static void Setup()
        {
            var site = new AdiliciousWebsite(new FirefoxDriver());
            site.Start(defaultPort);
            FeatureContext.Current.Set(site);
        }

        [AfterFeature]
        public static void Teardown()
        {
            FeatureContext.Current.Get<AdiliciousWebsite>().Stop();
        }

        [Given(@"I want to display (All|Cover|Top|TopBrands) ads")]
        public void GivenIWantToDisplayAds(AdDisplay display)
        {
            FeatureContext.Current.Get<AdiliciousWebsite>().GetPage(display).Navigate(defaultPort);
        }
    }
}