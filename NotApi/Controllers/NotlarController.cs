using Microsoft.AspNetCore.Mvc;
using NotApi.Application.Dtos;
using NotApi.Application.Interfaces; 


namespace NotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotlarController : ControllerBase
    {
        private readonly INotService _notService;

        public NotlarController(INotService notService)
        {
            _notService = notService;
        }

        [HttpGet]
        public IActionResult TumNotlariGetir()
        {
            var notlar = _notService.TumNotlariGetir();
            return Ok(notlar);
        }

        [HttpGet("{id}")]
        public IActionResult NotGetir(int id)
        {
            var not = _notService.NotGetir(id);
            if (not == null)
                return NotFound();

            return Ok(not);
        }

        [HttpPost]
        public IActionResult NotEkle([FromBody] NotDto notDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eklenenNot = _notService.NotEkle(notDto);
            return CreatedAtAction(nameof(NotGetir), new { id = eklenenNot.Id }, eklenenNot);
        }

        [HttpPut("{id}")]
        public IActionResult NotGuncelle(int id, [FromBody] NotDto notDto)
        {
            try
            {
                _notService.NotGuncelle(id, notDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult NotSil(int id)
        {
            try
            {
                _notService.NotSil(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("ortalama")]
        public IActionResult OrtalamaHesapla([FromBody] List<int> notlar)
        {
            if (notlar == null || notlar.Count == 0)
            {
                return BadRequest("Not listesi boş olamaz.");
            }

            try
            {
                var ortalama = _notService.OrtalamaHesapla(notlar);
                return Ok(new { Ortalama = ortalama });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata oluştu: {ex.Message}");
            }
        }
    }
}
