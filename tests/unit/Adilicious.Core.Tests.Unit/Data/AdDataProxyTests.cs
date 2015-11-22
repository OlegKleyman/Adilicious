namespace Adilicious.Core.Tests.Unit.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Mediaradar;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AdDataProxyTests
    {
        private readonly Mock<IAdDataService> adDataService = new Mock<IAdDataService>();

        [TestFixtureSetUp]
        public void Setup()
        {
            var ads = GetAds();
            adDataService.Setup(
                service => service.GetAdDataByDateRange(new DateTime(2011, 1, 1), new DateTime(2011, 4, 1)))
                .Returns(ads.ToArray());
        }

        [Test]
        public void GetAllShouldReturnAllAds()
        {
            var proxy = GetAdDataProxy();

            var ads = proxy.GetAll().ToList();

            Assert.That(ads.Count, Is.EqualTo(8));
            Assert.That(ads[0].AdId, Is.EqualTo(1));
            Assert.That(ads[1].AdId, Is.EqualTo(2));
            Assert.That(ads[2].AdId, Is.EqualTo(3));
            Assert.That(ads[3].AdId, Is.EqualTo(4));
            Assert.That(ads[4].AdId, Is.EqualTo(5));
            Assert.That(ads[5].AdId, Is.EqualTo(6));
            Assert.That(ads[6].AdId, Is.EqualTo(7));
            Assert.That(ads[7].AdId, Is.EqualTo(8));
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

        private AdDataProxy GetAdDataProxy()
        {
            return new AdDataProxy(adDataService.Object);
        }
    }
}
