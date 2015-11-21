namespace Adilicious.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Adilicious.Core;
    using Adilicious.Web.Models;

    public class HomeController : Controller
    {
        private readonly IAdRepository adRepository;

        public HomeController(IAdRepository adRepository)
        {
            this.adRepository = adRepository;
        }

        public ViewResult Index()
        {
            return View("index");
        }

        public ViewResult All()
        {
            ViewBag.Title = "All Results";

            var ads = adRepository.GetAll();

            return View("AdsWithAllColumns", ads.Select(ad => new AdViewModel
                                                    {
                                                        AdId = ad.AdId,
                                                        Position = ad.Position,
                                                        NumPages = ad.NumPages,
                                                        BrandId = ad.Brand.Id,
                                                        BrandName = ad.Brand.Name
                                                    }).OrderBy(model => model.BrandName));
        }

        public ViewResult Cover()
        {
            ViewBag.Title = "Cover Ads";

            var ads = adRepository.GetCoverAds();
            return View("AdsWithAllColumns", ads.Select(ad => new AdViewModel
            {
                AdId = ad.AdId,
                Position = ad.Position,
                NumPages = ad.NumPages,
                BrandId = ad.Brand.Id,
                BrandName = ad.Brand.Name
            }).OrderBy(model => model.BrandName));
        }

        public ViewResult TopBrands()
        {
            ViewBag.Title = "Top Brands";

            var ads = adRepository.GetTopBrandsByCoverage();
            return View("TopFive", ads.Select(ad => new AdViewModel
            {
                AdId = ad.AdId,
                Position = ad.Position,
                NumPages = ad.NumPages,
                BrandId = ad.Brand.Id,
                BrandName = ad.Brand.Name
            }));
        }
    }
}