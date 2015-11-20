namespace Adilicious.Tests.Integration
{
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {
        [BeforeFeature]
        public static void Setup()
        {
            var site = new AdiliciousWebsite();
            site.Start();
            FeatureContext.Current.Set(site);
        }

        [AfterFeature]
        public static void Teardown()
        {
            FeatureContext.Current.Get<AdiliciousWebsite>().Stop();
        }
    }
}
