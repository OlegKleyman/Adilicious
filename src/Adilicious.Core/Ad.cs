namespace Adilicious.Core
{
    using System;

    public class Ad : IEquatable<Ad>
    {
        public int AdId { get; set; }

        public Brand Brand { get; set; }

        public decimal NumPages { get; set; }

        public Position Position { get; set; }

        public bool Equals(Ad other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            return NumPages == other.NumPages;
        }

        public override int GetHashCode()
        {
            var brandHash = Brand == null ? 0 : Brand.GetHashCode();
            return AdId.GetHashCode() ^ brandHash ^ NumPages.GetHashCode() ^ Position.GetHashCode();
        }
    }
}