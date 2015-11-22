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
            const string adParamName = "ad";

            if (dataAd == null)
            {
                throw new ArgumentNullException(adParamName);
            }

            Position position;

            if (!Enum.TryParse(dataAd.Position, true, out position))
            {
                throw new ArgumentException(
                    String.Format(CultureInfo.InvariantCulture, "Invalid position: {0}", dataAd.Position),
                    adParamName);
            }

            return new Ad
                       {
                           Brand = Brand.FromDataBrand(dataAd.Brand),
                           Position = position,
                           NumPages = dataAd.NumPages,
                           AdId = dataAd.AdId
                       };
        }
    }
}