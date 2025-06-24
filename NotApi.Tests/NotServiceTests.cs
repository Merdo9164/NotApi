using NotApi.Application.Interfaces;
using NotApi.Application.Dtos;
using NotApi.Infrastructure.Services;
using NotApi.Domain.Entities;
using Xunit;

namespace NotApi.Tests
{
    public class NotServiceTests
    {
        [Fact]
        public void OrtalamaHesapla_DogruSonucVeriyor()
        {
            // Arrange
            var service = new NotService();
            var notlar = new List<int> { 70, 80, 90 };

            // Act
            var sonuc = service.OrtalamaHesapla(notlar);

            // Assert
            Assert.Equal(80, sonuc);
        }

        [Fact]
        public void OrtalamaHesapla_BosListeHataFirlatir()
        {
            // Arrange
            var service = new NotService();
            var notlar = new List<int>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.OrtalamaHesapla(notlar));
        }
    }
}
