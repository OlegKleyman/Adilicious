namespace Adilicious.Core
{
    public class Ad
    {
        public int AdId { get; set; }

        public Brand Brand { get; set; }

        public decimal NumPages { get; set; }

        public Position Position { get; set; }
    }
}