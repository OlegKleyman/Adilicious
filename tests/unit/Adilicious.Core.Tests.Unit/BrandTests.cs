namespace Adilicious.Core.Tests.Unit
{
    using NUnit.Framework;

    [TestFixture]
    public class BrandTests
    {
        [Test]
        public void FromDataBrandShouldReturnBusinessBrand()
        {
            var brand = Brand.FromDataBrand(new Mediaradar.Brand { BrandName = "test", BrandId = 2 });

            Assert.That(brand.Id, Is.EqualTo(2));
            Assert.That(brand.Name, Is.EqualTo("test"));
        }
    }
}
