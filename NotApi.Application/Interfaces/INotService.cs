using NotApi.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotApi.Application.Interfaces
{
    public interface INotService
    {
        Task<List<NotDto>> TumNotlariGetirAsync();
        Task<NotDto?> NotGetirAsync(int id);
        Task<NotDto> NotEkleAsync(NotDto notDto);
        Task NotGuncelleAsync(int id, NotDto notDto);
        Task NotSilAsync(int id);
        Task<double> OrtalamaHesaplaAsync(List<int> notlar);
    }
}
