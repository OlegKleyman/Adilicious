namespace Adilicious.Tests.Integration
{
    using TechTalk.SpecFlow;

    [Binding]
    public class TopChartsSteps
    {
        [Then(@"the ads should be sorted by Brand Name and coverage amount")]
        public void ThenTheAdsShouldBeSortedByBrandNameAndCoverageAmount()
        {
            // TODO: implement step with real data
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the ads sorted by coverage amount and then brand")]
        public void ThenIShouldSeeTheAdsSortedByCoverageAmountAndThenBrand()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it should be distinct by brand")]
        public void ThenItShouldBeDistinctByBrand()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
