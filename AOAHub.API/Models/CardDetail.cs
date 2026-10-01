namespace AOAHub.API.Models
{
    public class CardDetail
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Cost { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? SubType { get; set; }
        public string? Text { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public string? ImageUrl { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = string.Empty;

        public int SetId { get; set; }
        public string SetCode { get; set; } = string.Empty;
        public string SetName { get; set; } = string.Empty;
        public string? SetImageUrl { get; set; }
        public DateTime? SetReleaseDate { get; set; }
    }
}
