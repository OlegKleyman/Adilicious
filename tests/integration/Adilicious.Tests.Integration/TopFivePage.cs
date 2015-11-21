namespace Adilicious.Tests.Integration
{
    using OpenQA.Selenium;

    public abstract class TopFivePage : AdiliciousPage
    {
        public TopFivePage(IWebDriver driver)
            : base(driver)
        {
        }
    }
}