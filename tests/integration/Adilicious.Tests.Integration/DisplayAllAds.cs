namespace Adilicious.Tests.Integration
{
    using TechTalk.SpecFlow;

    [Binding]
    public class DisplayAllAds
    {
        [Given(@"I want to display All ads")]
        public void GivenIWantToDisplayAllAds()
        {
            ScenarioContext.Current.Pending();
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
