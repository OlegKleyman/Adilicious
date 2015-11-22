namespace Adilicious.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adilicious.Core.Data;

    public class AdRepository : IAdRepository
    {
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ad> GetTopAds()
        {
            const int topAdCount = 5;
            
            return adProxy.GetTopAds(topAdCount).Select(Ad.FromDataAd);
        }
    }
}