using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NotApi.Tests
{
    public class NotlarTests
    {
        [Fact]
        public void OrtalamaDogruHesaplaniyorMu()
        {
            // Arrange
            var notlar = new List<int> { 90, 80, 70 };

            // Act
            var ortalama = notlar.Average();

            // Assert
            Assert.Equal(80, ortalama);
        }
    }
}
