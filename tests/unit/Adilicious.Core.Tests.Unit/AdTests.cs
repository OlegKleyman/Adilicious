namespace Adilicious.Core.Tests.Unit
{
    using Adilicious.Core.Mediaradar;

    using NUnit.Framework;

    using Ad = Adilicious.Core.Ad;

    [TestFixture]
    public class AdTests
    {
        [Test]
        public void FromDataAdShouldReturnBusinessAd()
        {
            var ad =
                Ad.FromDataAd(
                    new Mediaradar.Ad
                        {
                            Brand = new Brand { BrandName = "Test", BrandId = 1 },
                            Position = "Cover",
                            NumPages = 1,
                            AdId = 2
                        });

            Assert.That(ad.Brand.Name, Is.EqualTo("Test"));
            Assert.That(ad.Brand.Id, Is.EqualTo(1));
            Assert.That(ad.Position, Is.EqualTo(Position.Cover));
            Assert.That(ad.NumPages, Is.EqualTo(1));
            Assert.That(ad.AdId, Is.EqualTo(2));
        }
    }
}
