namespace Adilicious.Tests.Integration
{
    using System.Linq;

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
            ScenarioContext.Current.Pending();
        }

        [When(@"I click the (.+) column")]
        public void WhenIClickTheColumn(string columnName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the data should be sorted")]
        public void ThenTheDataShouldBeSorted(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
