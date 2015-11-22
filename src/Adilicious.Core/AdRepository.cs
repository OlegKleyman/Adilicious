namespace Adilicious.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Data;

    public class AdRepository : IAdRepository
    {
        private const int TopChartCount = 5;

        private readonly IAdDataProxy adProxy;

        public AdRepository(IAdDataProxy adProxy)
        {
            if (adProxy == null)
            {
                throw new ArgumentNullException("adProxy");
            }

            this.adProxy = adProxy;
        }

        public IEnumerable<Ad> GetAll()
        {
            return adProxy.GetAll().Select(Ad.FromDataAd);
        }

        public IEnumerable<Ad> GetCoverAds()
        {
            return adProxy.GetByPosition(Position.Cover.ToString()).Select(Ad.FromDataAd);
        }

        public IEnumerable<Ad> GetTopBrandsByCoverage()
        {
            return adProxy.GetTopBrands(TopChartCount).Select(Ad.FromDataAd);
        }

        public IEnumerable<Ad> GetTopAds()
        {
            return adProxy.GetTopAds(TopChartCount).Select(Ad.FromDataAd);
        }
    }
}