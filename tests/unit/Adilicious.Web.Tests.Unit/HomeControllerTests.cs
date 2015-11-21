namespace Adilicious.Web.Tests.Unit
{
    using Adilicious.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexShouldReturnView()
        {
            var controller = GetHomeController();
            var index = controller.Index();
            Assert.That(index, Is.Not.Null);
            Assert.That(index.ViewBag.Title, Is.EqualTo("Index"));
        }

        private HomeController GetHomeController()
        {
            return new HomeController();
        }
    }
}
