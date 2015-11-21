namespace Adilicious.Core
{
    using System.Collections.Generic;

    public interface IAdRepository
    {
        IEnumerable<Ad> GetAll();

        IEnumerable<Ad> GetCoverAds();

        IEnumerable<Ad> GetTopBrandsByCoverage();

        IEnumerable<Ad> GetTopAds();
    }
}