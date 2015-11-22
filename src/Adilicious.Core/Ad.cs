namespace Adilicious.Core
{
    using System;
    using System.Globalization;

    public class Ad
    {
        public int AdId { get; set; }

        public Brand Brand { get; set; }

        public decimal NumPages { get; set; }

        public Position Position { get; set; }

        public static Ad FromDataAd(Mediaradar.Ad dataAd)
        {
            if (dataAd == null)
            {
                throw new ArgumentNullException("ad");
            }

            Position position;

            return new Ad
                       {
                           Brand = Brand.FromDataBrand(dataAd.Brand),
                           Position = Enum.TryParse(dataAd.Position, true, out position) ? position : default(Position),
                           NumPages = dataAd.NumPages,
                           AdId = dataAd.AdId
                       };
        }
    }
}