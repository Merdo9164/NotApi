using NotApi.Application.Dtos;
using NotApi.Application.Interfaces;
using NotApi.Domain.Entities;
using NotApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace NotApi.Infrastructure.Services
{
    public class NotService : INotService
    {
        private readonly NotDbContext _context;

        public NotService(NotDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotDto>> TumNotlariGetirAsync()
        {
            return await _context.Notlar
                .Select(n => new NotDto
                {
                    Id = n.Id,
                    Deger = n.Deger,
                    Aciklama = n.Aciklama
                })
                .ToListAsync();
        }

        public async Task<NotDto?> NotGetirAsync(int id)
        {
            var not = await _context.Notlar.FindAsync(id);
            if (not == null) return null;

            return new NotDto
            {
                Id = not.Id,
                Deger = not.Deger,
                Aciklama = not.Aciklama
            };
        }

        public async Task<NotDto> NotEkleAsync(NotDto dto)
        {
            var yeniNot = new Not
            {
                Deger = dto.Deger,
                Aciklama = dto.Aciklama
            };

            _context.Notlar.Add(yeniNot);
            await _context.SaveChangesAsync();

            dto.Id = yeniNot.Id;
            return dto;
        }

        public async Task NotGuncelleAsync(int id, NotDto dto)
        {
            var mevcut = await _context.Notlar.FindAsync(id);
            if (mevcut == null)
                throw new Exception("Not bulunamadı.");

            mevcut.Deger = dto.Deger;
            mevcut.Aciklama = dto.Aciklama;

            await _context.SaveChangesAsync();
        }

        public async Task NotSilAsync(int id)
        {
            var not = await _context.Notlar.FindAsync(id);
            if (not == null)
                throw new Exception("Not bulunamadı.");

            _context.Notlar.Remove(not);
            await _context.SaveChangesAsync();
        }

        public async Task<double> OrtalamaHesaplaAsync(List<int> notlar)
        {
            if (notlar == null || notlar.Count == 0)
                throw new ArgumentException("Not listesi boş olamaz.");

            return await Task.FromResult(notlar.Average());
        }


    }
}
