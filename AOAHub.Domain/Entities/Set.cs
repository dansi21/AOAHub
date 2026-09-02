namespace AOAHub.Domain.Entities;

public class Set
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime? ReleaseDate { get; set; }
}
