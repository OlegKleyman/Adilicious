namespace Adilicious.Web.Tests.Unit
{
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core;
    using Adilicious.Web.Controllers;
    using Adilicious.Web.Models;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class HomeControllerTests
    {
        private readonly Mock<IAdRepository> repository = new Mock<IAdRepository>();

        [TestFixtureSetUp]
        public void Setup()
        {
            var ads = GetAds();

            repository.Setup(adRepository => adRepository.GetAll()).Returns(ads);
            repository.Setup(adRepository => adRepository.GetCoverAds()).Returns(ads.Where(ad => ad.Position == Position.Cover));
            
            var groupedAds =
                ads.GroupBy(ad => ad.Brand.Id)
                    .Select(
                        grouping =>
                        new Ad
                            {
                                Brand = new Brand(grouping.Key, grouping.First().Brand.Name),
                                NumPages = grouping.Sum(ad => ad.NumPages)
                            }).OrderByDescending(ad => ad.NumPages).ThenBy(ad => ad.Brand.Name);

            repository.Setup(adRepository => adRepository.GetTopBrandsByCoverage()).Returns(groupedAds.Take(5));
        }

        private static IEnumerable<Ad> GetAds()
        {
            var ads = new List<Ad>();

            ads.Add(new Ad
            {
                AdId = 1,
                NumPages = 0.5m,
                Position = Position.Page,
                Brand = new Brand(1, "WSOP")
            });

            ads.Add(new Ad
            {
                AdId = 2,
                NumPages = 1,
                Position = Position.Page,
                Brand = new Brand(2, "Borgata")
            });

            ads.Add(new Ad
            {
                AdId = 3,
                NumPages = 1,
                Position = Position.Cover,
                Brand = new Brand(3, "WPT")
            });

            ads.Add(new Ad
            {
                AdId = 4,
                NumPages = 0.5m,
                Position = Position.Cover,
                Brand = new Brand(2, "Borgata")
            });

            ads.Add(new Ad
            {
                AdId = 5,
                NumPages = 1,
                Position = Position.Page,
                Brand = new Brand(4, "CNN")
            });

            ads.Add(new Ad
            {
                AdId = 6,
                NumPages = 1,
                Position = Position.Cover,
                Brand = new Brand(1, "WSOP")
            });

            ads.Add(new Ad
            {
                AdId = 7,
                NumPages = 1,
                Position = Position.Cover,
                Brand = new Brand(5, "ABC")
            });

            ads.Add(new Ad
            {
                AdId = 8,
                NumPages = 3.5m,
                Position = Position.Page,
                Brand = new Brand(6, "Samsung")
            });

            return ads;
        }

        [Test]
        public void IndexShouldReturnView()
        {
            var controller = GetHomeController();
            var index = controller.Index();
            Assert.That(index.ViewName, Is.EqualTo("index"));
            Assert.That(index, Is.Not.Null);
        }

        [Test]
        public void AllShouldReturnAdsSorted()
        {
            var controller = GetHomeController();

            var all = controller.All();
            Assert.That(all, Is.Not.Null);
            Assert.That(all.ViewBag.Title, Is.EqualTo("All Results"));
            Assert.That(all.ViewName, Is.EqualTo("AdsWithAllColumns"));
            Assert.That(all.Model, Is.InstanceOf<IEnumerable<AdViewModel>>());

            var model = ((IEnumerable<AdViewModel>)all.Model).ToList();

            Assert.That(model.Count, Is.EqualTo(8));
            Assert.That(model, Is.Ordered.By("BrandName"));
        }

        [Test]
        public void CoverShouldReturnOnlyCoverAdsSorted()
        {
            var controller = GetHomeController();

            var cover = controller.Cover();
            Assert.That(cover, Is.Not.Null);
            Assert.That(cover.ViewBag.Title, Is.EqualTo("Cover Ads"));
            Assert.That(cover.ViewName, Is.EqualTo("AdsWithAllColumns"));
            Assert.That(cover.Model, Is.InstanceOf<IEnumerable<AdViewModel>>());

            var model = ((IEnumerable<AdViewModel>)cover.Model).ToList();

            Assert.That(model.Count, Is.EqualTo(4));
            Assert.That(model, Is.Ordered.By("BrandName"));
        }

        [Test]
        public void TopBrandsShouldReturnOnlyCoverAdsSorted()
        {
            var controller = GetHomeController();

            var cover = controller.TopBrands();
            Assert.That(cover, Is.Not.Null);
            Assert.That(cover.ViewBag.Title, Is.EqualTo("Top Brands"));
            Assert.That(cover.ViewName, Is.EqualTo("TopFive"));
            Assert.That(cover.Model, Is.InstanceOf<IEnumerable<AdViewModel>>());

            var model = ((IEnumerable<AdViewModel>)cover.Model).ToList();

            Assert.That(model.Count, Is.EqualTo(5));

            Assert.That(model[0].NumPages, Is.EqualTo(3.5));
            Assert.That(model[0].BrandName, Is.EqualTo("Samsung"));
            Assert.That(model[1].NumPages, Is.EqualTo(1.5));
            Assert.That(model[1].BrandName, Is.EqualTo("Borgata"));
            Assert.That(model[2].NumPages, Is.EqualTo(1.5));
            Assert.That(model[2].BrandName, Is.EqualTo("WSOP"));
            Assert.That(model[3].NumPages, Is.EqualTo(1));
            Assert.That(model[3].BrandName, Is.EqualTo("ABC"));
            Assert.That(model[4].NumPages, Is.EqualTo(1));
            Assert.That(model[4].BrandName, Is.EqualTo("CNN"));
        }

        private HomeController GetHomeController()
        {
            return new HomeController(repository.Object);
        }
    }
}
