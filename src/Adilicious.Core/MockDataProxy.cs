namespace Adilicious.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Adilicious.Core.Data;

    using MoreLinq;

    public class MockDataProxy : IAdDataProxy
    {
        private readonly string jsonPath;

        public MockDataProxy(string jsonPath)
        {
            if (jsonPath == null)
            {
                throw new ArgumentNullException("jsonPath");
            }

            this.jsonPath = jsonPath;
        }

        public IEnumerable<Mediaradar.Ad> GetByPosition(string position)
        {
            var serializer = new JavaScriptSerializer();

            var ads = serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath)).Where(ad => ad.Position == "Cover");

            return ads;
        }

        public IEnumerable<Mediaradar.Ad> GetTopAds(int count)
        {
            var serializer = new JavaScriptSerializer();

            var ads =
                serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath))
                    .OrderByDescending(ad => ad.NumPages)
                    .ThenBy(ad => ad.Brand.BrandName)
                    .DistinctBy(ad => ad.Brand.BrandName)
                    .Take(5);

            return ads;
        }

        public IEnumerable<Mediaradar.Ad> GetTopBrands(int count)
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

            return ads;
        }

        IEnumerable<Mediaradar.Ad> IAdDataProxy.GetAll()
        {
            var serializer = new JavaScriptSerializer();

            var ads = serializer.Deserialize<Mediaradar.Ad[]>(File.ReadAllText(jsonPath));

            return ads;
        }
    }
}