namespace Adilicious.Core.Tests.Unit
{
    using NUnit.Framework;

    [TestFixture]
    public class AdTests
    {
        public static object[] equalsShouldEquateAdsSource =
            {
                new object[]
                    {
                        new Ad { NumPages = 3 },
                        new Ad { NumPages = 1 },
                        false
                    },
                
                new object[]
                    {
                        new Ad { NumPages = 3 },
                        new Ad { NumPages = 3 },
                        true
                    },
                
                new object[]
                    {
                        new Ad { NumPages = 1 },
                        new Ad { NumPages = 3 },
                        false
                    }
            };

        [TestCaseSource("equalsShouldEquateAdsSource")]
        public void EqualsShouldEquateAds(Ad ad, Ad other, bool expected)
        {
            Assert.That(ad.Equals(other), Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCodeShouldReturnHash()
        {
            var ad = new Ad { Brand = new Brand(10, "test"), NumPages = 3, AdId = 1 };
            Assert.That(ad.GetHashCode(), Is.EqualTo(-1944423539));
        }
    }
}
