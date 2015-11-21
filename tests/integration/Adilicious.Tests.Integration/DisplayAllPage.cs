namespace Adilicious.Tests.Integration
{
    using OpenQA.Selenium;

    public class DisplayAllPage : AdiliciousPage
    {
        public DisplayAllPage(IWebDriver driver) : base(driver)
        {
            
        }

        public override void ClickPageLink()
        {
            Driver.FindElement(By.LinkText("All")).Click();
        }
    }
}