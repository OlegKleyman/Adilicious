namespace Adilicious.Core.Tests.Unit
{
    using NUnit.Framework;

    [TestFixture]
    public class BrandTests
    {
        [Test]
        public void GetHashCodeShouldReturnHash()
        {
            var brand = new Brand(10, "test");
            Assert.That(brand.GetHashCode(), Is.EqualTo(-871206004));
        }
    }
}
