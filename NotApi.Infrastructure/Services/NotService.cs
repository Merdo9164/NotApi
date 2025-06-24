using NotApi.Domain.Entities;
using NotApi.Application.Dtos;
using System.Collections.Generic;
using NotApi.Application.Interfaces;
using System.Linq;
using System;

namespace NotApi.Infrastructure.Services
{
    public class NotService : INotService
    {
        private readonly List<Not> _notlar = new();

        public List<NotDto> TumNotlariGetir()
        {
            return _notlar.Select(n => new NotDto
            {
                Id = n.Id,
                Deger = n.Deger,
                Aciklama = n.Aciklama
            }).ToList();
        }

        public NotDto? NotGetir(int id)
        {
            var not = _notlar.FirstOrDefault(n => n.Id == id);
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
                Id = _notlar.Count > 0 ? _notlar.Max(n => n.Id) + 1 : 1,
                Deger = dto.Deger,
                Aciklama = dto.Aciklama
            };
            _notlar.Add(yeniNot);

            return new NotDto
            {
                Id = yeniNot.Id,
                Deger = yeniNot.Deger,
                Aciklama = yeniNot.Aciklama
            };
        }

        public void NotGuncelle(int id, NotDto dto)
        {
            var mevcut = _notlar.FirstOrDefault(n => n.Id == id);
            if (mevcut == null)
                throw new Exception("Not bulunamadı.");

            mevcut.Deger = dto.Deger;
            mevcut.Aciklama = dto.Aciklama;
        }

        public void NotSil(int id)
        {
            var not = _notlar.FirstOrDefault(n => n.Id == id);
            if (not == null)
                throw new Exception("Not bulunamadı.");

            _notlar.Remove(not);
        }

        public double OrtalamaHesapla(List<int> notlar)
        {
            if (notlar == null || notlar.Count == 0)
                return 0;

            return notlar.Average();
        }
    }
}
