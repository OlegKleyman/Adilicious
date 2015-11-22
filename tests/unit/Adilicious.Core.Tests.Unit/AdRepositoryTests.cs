namespace Adilicious.Core.Tests.Unit
{
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Data;
    using Adilicious.Core.Mediaradar;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AdRepositoryTests
    {
        private readonly Mock<IAdDataProxy> adDataProxy = new Mock<IAdDataProxy>();

        [TestFixtureSetUp]
        public void Setup()
        {
            var ads = GetAds();
            adDataProxy.Setup(proxy => proxy.GetAll()).Returns(ads);
        }

        private static IEnumerable<Ad> GetAds()
        {
            var ads = new List<Ad>();

            ads.Add(
                new Ad
                    {
                        AdId = 1,
                        NumPages = 0.5m,
                        Position = Position.Page.ToString(),
                        Brand = new Brand { BrandId = 1, BrandName = "WSOP" }
                    });

            ads.Add(new Ad
            {
                AdId = 2,
                NumPages = 1,
                Position = Position.Page.ToString(),
                Brand = new Brand { BrandId = 2, BrandName = "Borgata" }
            });

            ads.Add(new Ad
            {
                AdId = 3,
                NumPages = 1,
                Position = Position.Cover.ToString(),
                Brand = new Brand { BrandId = 3, BrandName = "WPT" }
            });

            ads.Add(new Ad
            {
                AdId = 4,
                NumPages = 0.5m,
                Position = Position.Cover.ToString(),
                Brand = new Brand { BrandId = 2, BrandName = "Borgata" }
            });

            ads.Add(new Ad
            {
                AdId = 5,
                NumPages = 1,
                Position = Position.Page.ToString(),
                Brand = new Brand { BrandId = 4, BrandName = "CNN" }
            });

            ads.Add(new Ad
            {
                AdId = 6,
                NumPages = 1,
                Position = Position.Cover.ToString(),
                Brand = new Brand { BrandId = 1, BrandName = "WSOP" }
            });

            ads.Add(new Ad
            {
                AdId = 7,
                NumPages = 1,
                Position = Position.Cover.ToString(),
                Brand = new Brand { BrandId = 5, BrandName = "ABC" }
            });

            ads.Add(new Ad
            {
                AdId = 8,
                NumPages = 3.5m,
                Position = Position.Page.ToString(),
                Brand = new Brand { BrandId = 6, BrandName = "Samsung" }
            });

            return ads;
        }

        [Test]
        public void GetAllShouldReturnAllAds()
        {
            var repository = GetRepository();
            var all = repository.GetAll().ToList();

            Assert.That(all.Count, Is.EqualTo(8));
            Assert.That(all[0].AdId, Is.EqualTo(1));
            Assert.That(all[1].AdId, Is.EqualTo(2));
            Assert.That(all[2].AdId, Is.EqualTo(3));
            Assert.That(all[3].AdId, Is.EqualTo(4));
            Assert.That(all[4].AdId, Is.EqualTo(5));
            Assert.That(all[5].AdId, Is.EqualTo(6));
            Assert.That(all[6].AdId, Is.EqualTo(7));
            Assert.That(all[7].AdId, Is.EqualTo(8));
        }

        private IAdRepository GetRepository()
        {
            return new AdRepository(adDataProxy.Object);
        }
    }
}
