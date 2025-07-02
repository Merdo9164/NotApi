using Microsoft.AspNetCore.Mvc;
using NotApi.Application.Interfaces;
using NotApi.Application.Dtos;

namespace NotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotlarController : ControllerBase
    {
        private readonly INotService _notService;

        public NotlarController(INotService notService)
        {
            _notService = notService;
        }

        [HttpGet]
        public async Task<IActionResult> TumNotlariGetir()
        {
            var notlar = await _notService.TumNotlariGetirAsync();
            return Ok(notlar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> NotGetir(int id)
        {
            var not = await _notService.NotGetirAsync(id);
            if (not == null) return NotFound();
            return Ok(not);
        }

        [HttpPost]
        public async Task<IActionResult> NotEkle([FromBody] NotDto dto)
        {
            var yeniNot = await _notService.NotEkleAsync(dto);
            return CreatedAtAction(nameof(NotGetir), new { id = yeniNot.Id }, yeniNot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> NotGuncelle(int id, [FromBody] NotDto dto)
        {
            await _notService.NotGuncelleAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> NotSil(int id)
        {
            await _notService.NotSilAsync(id);
            return NoContent();
        }
    }
}
