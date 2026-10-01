namespace AOAHub.UI.Models;

public class ArtistSummary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CardCount { get; set; }
    public string? ImageUrl { get; set; }
    public string? LinkBlob { get; set; }
}
