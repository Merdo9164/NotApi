// INotService.cs
using NotApi.Application.Dtos;
using System.Collections.Generic;

namespace NotApi.Application.Interfaces
{
    public interface INotService
    {
        List<NotDto> TumNotlariGetir();
        NotDto? NotGetir(int id);
        NotDto NotEkle(NotDto notDto);
        void NotGuncelle(int id, NotDto notDto);
        void NotSil(int id);
        double OrtalamaHesapla(List<int> notlar);
    }
}
