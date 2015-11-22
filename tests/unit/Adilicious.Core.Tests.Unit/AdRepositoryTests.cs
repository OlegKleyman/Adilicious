namespace Adilicious.Core.Tests.Unit
{
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Data;
    using Adilicious.Core.Mediaradar;

    using Moq;

    using MoreLinq;

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
            adDataProxy.Setup(proxy => proxy.GetByPosition("Cover")).Returns(ads.Where(ad => ad.Position == "Cover"));

            var topAds =
                ads.OrderByDescending(ad => ad.NumPages)
                    .ThenBy(ad => ad.Brand.BrandName)
                    .DistinctBy(ad => ad.Brand.BrandName);

            adDataProxy.Setup(proxy => proxy.GetTopAds(5)).Returns(topAds.Take(5));

            var topBrands =
                ads.GroupBy(ad => ad.Brand.BrandId)
                    .Select(
                        grouping =>
                        new Ad
                            {
                                Brand =
                                    new Brand
                                        {
                                            BrandId = grouping.Key,
                                            BrandName = grouping.First().Brand.BrandName
                                        },
                                NumPages = grouping.Sum(ad => ad.NumPages)
                            })
                    .OrderByDescending(ad => ad.NumPages)
                    .ThenBy(ad => ad.Brand.BrandName);

            adDataProxy.Setup(proxy => proxy.GetTopBrands(5)).Returns(topBrands.Take(5));
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

        [Test]
        public void GetCoverAdsShouldReturnAllCoverAds()
        {
            var repository = GetRepository();
            var all = repository.GetCoverAds().ToList();

            Assert.That(all.Count, Is.EqualTo(4));
            Assert.That(all, Is.All.Property("Position").EqualTo(Position.Cover));
        }

        [Test]
        public void GetTopAdsShouldReturnTopFiveAds()
        {
            var repository = GetRepository();
            var all = repository.GetTopAds().ToList();

            Assert.That(all.Count, Is.EqualTo(5));
            Assert.That(all[0].AdId, Is.EqualTo(8));
            Assert.That(all[0].NumPages, Is.EqualTo(3.5));
            Assert.That(all[0].Brand.Id, Is.EqualTo(6));
            Assert.That(all[1].AdId, Is.EqualTo(7));
            Assert.That(all[1].NumPages, Is.EqualTo(1));
            Assert.That(all[1].Brand.Id, Is.EqualTo(5));
            Assert.That(all[2].AdId, Is.EqualTo(2));
            Assert.That(all[2].NumPages, Is.EqualTo(1));
            Assert.That(all[2].Brand.Id, Is.EqualTo(2));
            Assert.That(all[3].AdId, Is.EqualTo(5));
            Assert.That(all[3].NumPages, Is.EqualTo(1));
            Assert.That(all[3].Brand.Id, Is.EqualTo(4));
            Assert.That(all[4].AdId, Is.EqualTo(3));
            Assert.That(all[4].NumPages, Is.EqualTo(1));
            Assert.That(all[4].Brand.Id, Is.EqualTo(3));
        }

        [Test]
        public void GetTopBrandsShouldReturnTopFiveBrands()
        {
            var repository = GetRepository();
            var all = repository.GetTopBrandsByCoverage().ToList();

            Assert.That(all.Count, Is.EqualTo(5));
            Assert.That(all[0].NumPages, Is.EqualTo(3.5));
            Assert.That(all[0].Brand.Id, Is.EqualTo(6));
            Assert.That(all[1].NumPages, Is.EqualTo(1.5));
            Assert.That(all[1].Brand.Id, Is.EqualTo(2));
            Assert.That(all[2].NumPages, Is.EqualTo(1.5));
            Assert.That(all[2].Brand.Id, Is.EqualTo(1));
            Assert.That(all[3].NumPages, Is.EqualTo(1));
            Assert.That(all[3].Brand.Id, Is.EqualTo(5));
            Assert.That(all[4].NumPages, Is.EqualTo(1));
            Assert.That(all[4].Brand.Id, Is.EqualTo(4));
        }

        private IAdRepository GetRepository()
        {
            return new AdRepository(adDataProxy.Object);
        }
    }
}
