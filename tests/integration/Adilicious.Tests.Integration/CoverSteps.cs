namespace Adilicious.Tests.Integration
{
    using Adilicious.Core;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class CoverSteps
    {
        [Then(@"all results should have a cover position")]
        public void ThenAllResultsShouldHaveACoverPosition()
        {
            var allAds = ScenarioContext.Current.Get<AdiliciousPage>().GetAllAvailableAds();

            Assert.That(allAds, Has.All.Property("Position").EqualTo(Position.Cover));
        }
    }
}
