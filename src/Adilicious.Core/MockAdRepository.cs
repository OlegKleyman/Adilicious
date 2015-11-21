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
            var h = new Mediaradar.Ad();
            h.Position = "";
            return ads.Select(ad => new Ad
                                        {
                                            Position = (Position)Enum.Parse(typeof(Position), ad.Position, true),
                                            NumPages = ad.NumPages,
                                            AdId = ad.AdId,
                                            Brand = new Brand(ad.Brand.BrandId, ad.Brand.BrandName)
                                        });
        }
    }
}