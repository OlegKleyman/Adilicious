namespace Adilicious.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Data;
    using Adilicious.Core.Mediaradar;

    using MoreLinq;

    public class AdDataProxy : IAdDataProxy
    {
        private readonly IAdDataService service;

        private static readonly DateTime defaultDateStart = new DateTime(2011, 1, 1);
        private static readonly DateTime defaultDateEnd = new DateTime(2011, 4, 1);

        public AdDataProxy(IAdDataService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            this.service = service;
        }

        public IEnumerable<Mediaradar.Ad> GetByPosition(string position)
        {
            return GetDefaultAds().Where(ad => ad.Position == position);
        }

        public IEnumerable<Mediaradar.Ad> GetTopAds(int count)
        {
            return
                GetDefaultAds()
                    .OrderByDescending(ad => ad.NumPages)
                    .ThenBy(ad => ad.Brand.BrandName)
                    .DistinctBy(ad => ad.Brand.BrandName)
                    .Take(count);
        }

        public IEnumerable<Mediaradar.Ad> GetTopBrands(int count)
        {
            return GetDefaultAds().GroupBy(ad => ad.Brand.BrandId)
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
                    .ThenBy(ad => ad.Brand.BrandName).Take(5);
        }

        public IEnumerable<Mediaradar.Ad> GetAll()
        {
            return GetDefaultAds();
        }

        private Mediaradar.Ad[] GetDefaultAds()
        {
            return service.GetAdDataByDateRange(defaultDateStart, defaultDateEnd);
        }
    }
}