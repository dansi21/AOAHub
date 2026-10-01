namespace AOAHub.API.Models
{
    public class CardRow
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Cost { get; set; }
        public string TypeLine { get; set; } = string.Empty;
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public string? ImageUrl { get; set; }
    }
}
