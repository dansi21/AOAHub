namespace AOAHub.Domain.Entities;

public class Card
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Cost { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Text { get; set; }
    public int? Attack { get; set; }
    public int? Defense { get; set; }
    public string? SubType { get; set; }
    public string? ImageUrl { get; set; }

    public int ArtistId { get; set; }
    public int SetId { get; set; }
}
