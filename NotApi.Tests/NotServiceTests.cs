using NotApi.Application.Interfaces;
using NotApi.Application.Dtos;
using NotApi.Infrastructure.Services;
using NotApi.Domain.Entities;
using NotApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotApi.Tests
{
    public class NotServiceTests
    {
        private NotService GetServiceWithInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<NotDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new NotDbContext(options);
            return new NotService(context);
        }

        [Fact]
        public async Task OrtalamaHesapla_DogruSonucVeriyor()
        {
            // Arrange
            var service = GetServiceWithInMemoryDb();
            var notlar = new List<int> { 70, 80, 90 };

            // Act
            var sonuc = await service.OrtalamaHesaplaAsync(notlar);

            // Assert
            Assert.Equal(80, sonuc);
        }

        [Fact]
        public async Task OrtalamaHesapla_BosListeHataFirlatir()
        {
            // Arrange
            var service = GetServiceWithInMemoryDb();
            var notlar = new List<int>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => 
                await service.OrtalamaHesaplaAsync(notlar));
        }
    }
}
