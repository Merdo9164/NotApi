namespace NotApi.Application.Dtos
{
    public class NotDto
    {
        public int Id { get; set; }  // Eğer gerekiyorsa, yoksa kaldırabilirsin
        public int Deger { get; set; }  // Notun değeri (örnek)
        public string? Aciklama { get; set; }  // Notla ilgili açıklama (isteğe bağlı)
    }
}
