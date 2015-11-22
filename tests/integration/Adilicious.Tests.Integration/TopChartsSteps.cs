namespace Adilicious.Tests.Integration
{
    using System.Linq;

    using Adilicious.Tests.Integration.Mediaradar;

    using MoreLinq;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class TopChartsSteps
    {
        [Then(@"the ads should be sorted by Brand Name and coverage amount")]
        public void ThenTheAdsShouldBeSortedByBrandNameAndCoverageAmount()
        {
            var ads = ScenarioContext.Current.Get<AdiliciousPage>().GetDisplayedAds().ToList();

            Assert.That(ads[0].NumPages, Is.EqualTo(20));
            Assert.That(ads[0].BrandName, Is.EqualTo("Saks Fifth Avenue"));
            Assert.That(ads[1].NumPages, Is.EqualTo(19));
            Assert.That(ads[1].BrandName, Is.EqualTo("Chanel (Women)"));
            Assert.That(ads[2].NumPages, Is.EqualTo(16));
            Assert.That(ads[2].BrandName, Is.EqualTo("Neiman Marcus"));
            Assert.That(ads[3].NumPages, Is.EqualTo(16));
            Assert.That(ads[3].BrandName, Is.EqualTo("Nordstrom"));
            Assert.That(ads[4].NumPages, Is.EqualTo(16));
            Assert.That(ads[4].BrandName, Is.EqualTo("Tommy Hilfiger"));
        }

        [Then(@"I should see the ads sorted by coverage amount and then brand")]
        public void ThenIShouldSeeTheAdsSortedByCoverageAmountAndThenBrand()
        {
            var ads = ScenarioContext.Current.Get<AdiliciousPage>().GetDisplayedAds().ToList();

            Assert.That(ads[0].NumPages, Is.EqualTo(20));
            Assert.That(ads[0].BrandName, Is.EqualTo("Saks Fifth Avenue"));
            Assert.That(ads[1].NumPages, Is.EqualTo(16));
            Assert.That(ads[1].BrandName, Is.EqualTo("Neiman Marcus"));
            Assert.That(ads[2].NumPages, Is.EqualTo(16));
            Assert.That(ads[2].BrandName, Is.EqualTo("Nordstrom"));
            Assert.That(ads[3].NumPages, Is.EqualTo(8));
            Assert.That(ads[3].BrandName, Is.EqualTo("Vera Wang"));
            Assert.That(ads[4].NumPages, Is.EqualTo(6));
            Assert.That(ads[4].BrandName, Is.EqualTo("Barneys New York"));
        }

        [Then(@"it should be distinct by brand")]
        public void ThenItShouldBeDistinctByBrand()
        {
            var ads = ScenarioContext.Current.Get<AdiliciousPage>().GetDisplayedAds().DistinctBy(model => model.BrandName);

            Assert.That(ads.Count(), Is.EqualTo(5));
        }
    }
}
