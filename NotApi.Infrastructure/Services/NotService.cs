using NotApi.Domain.Entities;
using NotApi.Application.Dtos;
using System.Collections.Generic;
using NotApi.Application.Interfaces;
using NotApi.Infrastructure.Data;
using System.Linq;
using System;

namespace NotApi.Infrastructure.Services
{
    public class NotService : INotService
    {
        private readonly NotDbContext _context;

        public NotService(NotDbContext context)
        {
           _context = context;
        }


        public List<NotDto> TumNotlariGetir()
        {
            return _context.Notlar
            .Select(n => new NotDto
            {
                Id = n.Id,
                Deger = n.Deger,
                Aciklama = n.Aciklama
            }).ToList();
        }

        public NotDto? NotGetir(int id)
        {
            var not = _context.Notlar.Find(id);
            if (not == null) return null;

            return new NotDto
            {
                Id = not.Id,
                Deger = not.Deger,
                Aciklama = not.Aciklama
            };
        }

        public NotDto NotEkle(NotDto dto)
        {
            var yeniNot = new Not
            {
                Deger = dto.Deger,
                Aciklama = dto.Aciklama
            };

                 _context.Notlar.Add(yeniNot);
                _context.SaveChanges();

                dto.Id = yeniNot.Id;
                return dto;
        }

        public void NotGuncelle(int id, NotDto dto)
        {
            var mevcut = _context.Notlar.Find(id);
            if (mevcut == null)
                throw new Exception("Not bulunamadı.");

                mevcut.Deger = dto.Deger;
                mevcut.Aciklama = dto.Aciklama;
                _context.SaveChanges();
        }

        public void NotSil(int id)
        {
            var not = _context.Notlar.Find(id);
            if (not == null)
                throw new Exception("Not bulunamadı.");

            _context.Notlar.Remove(not);
            _context.SaveChanges();
        }


        public double OrtalamaHesapla(List<int> notlar)
        {
            if (notlar == null || notlar.Count == 0)
                throw new ArgumentException("Not listesi boş olamaz.");

            return notlar.Average();
        }

    }
}
