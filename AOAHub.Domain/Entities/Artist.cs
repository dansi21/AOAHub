namespace AOAHub.Domain.Entities;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? LinkBlob { get; set; }
}
