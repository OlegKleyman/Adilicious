namespace Adilicious.Tests.Integration
{
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
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be (.*) pages")]
        public void ThenThereShouldBePages(int pageCount)
        {
            ScenarioContext.Current.Pending();
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
