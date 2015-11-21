namespace Adilicious.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class MockAdRepository : IAdRepository
    {
        private readonly string jsonPath;

        public MockAdRepository(string jsonPath)
        {
            if (jsonPath == null)
            {
                throw new ArgumentNullException("jsonPath");
            }

            this.jsonPath = jsonPath;
        }

        public IEnumerable<Ad> GetAll()
        {
            var serializer = new JavaScriptSerializer();

            var ads = serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath));
            
            return ads.Select(ad => new Ad
                                        {
                                            Position = (Position)Enum.Parse(typeof(Position), ad.Position, true),
                                            NumPages = ad.NumPages,
                                            AdId = ad.AdId,
                                            Brand = new Brand(ad.Brand.BrandId, ad.Brand.BrandName)
                                        });
        }

        public IEnumerable<Ad> GetCoverAds()
        {
            var serializer = new JavaScriptSerializer();

            var ads = serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath)).Where(ad => ad.Position == "Cover");

            return ads.Select(ad => new Ad
            {
                Position = (Position)Enum.Parse(typeof(Position), ad.Position, true),
                NumPages = ad.NumPages,
                AdId = ad.AdId,
                Brand = new Brand(ad.Brand.BrandId, ad.Brand.BrandName)
            });
        }

        public IEnumerable<Ad> GetTopBrandsByCoverage()
        {
            var serializer = new JavaScriptSerializer();

            var ads =
                serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath))
                    .GroupBy(ad => ad.Brand.BrandId)
                    .Select(
                        grouping =>
                        new Mediaradar.Ad
                            {
                                Brand =
                                    new Mediaradar.Brand
                                        {
                                            BrandId = grouping.Key,
                                            BrandName = grouping.First().Brand.BrandName
                                        },
                                NumPages = grouping.Sum(ad => ad.NumPages)
                            })
                    .OrderByDescending(ad => ad.NumPages)
                    .ThenBy(ad => ad.Brand.BrandName)
                    .Take(5);

            return ads.Select(ad => new Ad
            {
                NumPages = ad.NumPages,
                Brand = new Brand(ad.Brand.BrandId, ad.Brand.BrandName)
            });
        }

        public IEnumerable<Ad> GetTopAds()
        {
            throw new NotImplementedException();
        }
    }
}