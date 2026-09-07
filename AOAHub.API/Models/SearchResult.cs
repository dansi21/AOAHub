namespace AOAHub.API.Models
{
    public class SearchResult
    {
        public string Type { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Weight { get; set; }
    }
}
