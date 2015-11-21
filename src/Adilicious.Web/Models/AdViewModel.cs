namespace Adilicious.Web.Models
{
    using Adilicious.Core;

    public class AdViewModel
    {
        public int AdId { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public decimal NumPages { get; set; }

        public Position Position { get; set; }
    }
}