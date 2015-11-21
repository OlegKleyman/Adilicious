namespace Adilicious.Tests.Integration
{
    using System;
    using System.Linq;
    using System.Threading;

    using Adilicious.Core;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class DisplayAllAds
    {
        private readonly AdiliciousWebsite website;

        public DisplayAllAds()
        {
            this.website = FeatureContext.Current.Get<AdiliciousWebsite>();
        }

        [Then(@"I should see (.*) ads a page")]
        public void ThenIShouldSeeAdsAPage(int adCount)
        {
            var ads = ScenarioContext.Current.Get<AdiliciousPage>().GetDisplayedAds().ToList();
            
            ScenarioContext.Current.Set(ads);
            Assert.That(ads.Count, Is.EqualTo(adCount));
        }

        [Then(@"there should be (.*) pages")]
        public void ThenThereShouldBePages(int pageCount)
        {
            var pages = ScenarioContext.Current.Get<AdiliciousPage>().GetAvailablePages();
            Assert.That(pages, Is.EqualTo(pageCount));
        }

        [Then(@"the data should be sorted")]
        public void ThenTheDataShouldBeSorted()
        {
            var allAds = ScenarioContext.Current.Get<AdiliciousPage>().GetAllAvailableAds();

            Assert.That(allAds, Is.Ordered.By(ScenarioContext.Current.Get<string>().Replace(" ", String.Empty)));
        }

        [When(@"I click the (.+) column")]
        public void WhenIClickTheColumn(string columnName)
        {
            ScenarioContext.Current.Get<AdiliciousPage>().SortBy(columnName);
            ScenarioContext.Current.Set(columnName);
            
            // Wait for javascript to finish executing
            Thread.Sleep(1000);
        }

        [Then(@"the data should be sorted")]
        public void ThenTheDataShouldBeSorted(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
